using DC.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DC.Node.Helpers
{
    public class Transaction
    {
        public Byte[] Version
        {
            get
            {
                return new Byte[4] { 0x01, 0x00, 0x00, 0x00 };
            }
        }

        public Byte[] LockTime
        {
            get
            {
                return new Byte[4] { 0x00, 0x00, 0x00, 0x00 };
            }
        }

        public Byte[] HashType
        {
            get
            {
                return new Byte[4] { 0x01, 0x00, 0x00, 0x00 };
            }
        }

        private Int64 _change = 0;
        public Byte[] Change
        {
            get;
            private set;
        }

        public Byte[] Value
        {
            get;
            private set;
        }

        public Byte NumTxIn
        {
            get
            {
                if (_outputsToSpend != null)
                {
                    return Convert.ToByte(_outputsToSpend.Count); //new Byte[1] { 0x01 };
                }
                else
                {
                    return Convert.ToByte(0);
                }
            }
        }

        public Byte NumTxOut
        {
            get
            {
                if (_change > 0)
                {
                    return Convert.ToByte(2);
                }
                else
                {
                    return Convert.ToByte(1);
                }
            }
        }

        public Byte[] OutPuts
        {
            get
            {
                return null;
            }
        }

        public Byte[] Sequence
        {
            get
            {
                return new Byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }; //FF FF FF FF
            }
        }

        private IList<DC.Common.Models.UnspentOutput> _outputsToSpend;

        public Transaction(IList<DC.Common.Models.UnspentOutput> outputsToSpend, DC.Common.Models.Address sourceAddress, String destinationAddress, String destinationHash160, Decimal amount, Decimal fee = 0.0001M)
        {
            //Amount to send + miners fee
            Int64 sum = (outputsToSpend.Sum(o => o.Value));

            if (sum > 0)
            {
                
                _change = sum - Convert.ToInt64(amount * DC.Common.Math.SATOSHI) - Convert.ToInt64(fee * DC.Common.Math.SATOSHI);

                //CHANGE
                this.Change = DC.Common.Math.GetValueAsBytes(_change);
                this.Value = DC.Common.Math.GetValueAsBytes(amount);

                _outputsToSpend = outputsToSpend;
            }
            else
            {
                throw new ArgumentNullException("No spendable outputs");
            }
        }

        public byte[] CreateAndSignTransaction(DC.Common.Models.Address sourceAddress, String destinationAddress, String destinationHash160, Decimal amount, Decimal fee = 0.0001M)
        {
            if (!DC.Common.BitcoinHelper.IsValidAddress(destinationAddress))
                throw new ArgumentException("Destination address is not valid");

            List<Byte[]> signedOutPuts = new List<byte[]>(_outputsToSpend.Count);

            //Loop each output to sign
            for (Int32 i = 0; i < _outputsToSpend.Count; i++)
            {
                //1
                Byte[] version = this.Version;
                Debug.Assert(version[0] == 1);
                Debug.Assert(version.Length == 4);

                //2
                Byte[] tx_fields = version.Concat(this.NumTxIn);
                Debug.Assert(tx_fields.Length == 5);

                //Write out each input
                for (Int32 j = 0; j < _outputsToSpend.Count; j++)
                {
                    //THIS IS HASH OF THE TRANSACTION THAT CONTAINS THE UNSPENT OUTPUT
                    //NB, ALREADY REVERSED!

                    //3
                    Byte[] prevout_hash = DC.Common.StringHelper.HexStringToByte(_outputsToSpend[j].TxHash);
                    tx_fields = tx_fields.Concat(prevout_hash);

                    //4 (index 0)
                    //4 BYTE ARRAY, WITH PREVIOUS INDEX EG 01 00 00 00
                    Byte[] output_index = _outputsToSpend[j].OutputIndexAsBytes;
                    Debug.Assert(output_index.Length == 4);

                    tx_fields = tx_fields.Concat(output_index);

                    if (i == j)
                    {
                        //SWAP.  NB WE HAVE THE SCRYPT, JUST CONVERT TO BYTES
                        Byte[] previousOutputScript = _outputsToSpend[j].ScryptAsBytes;

                        Byte previousOutputScriptLength = Convert.ToByte(previousOutputScript.Length);
                        tx_fields = tx_fields.Concat(previousOutputScriptLength);
                        tx_fields = tx_fields.Concat(previousOutputScript);
                    }
                    else
                    {
                        Byte zeroScript = Convert.ToByte(0);
                        tx_fields = tx_fields.Concat(zeroScript);
                    }

                    //7
                    tx_fields = tx_fields.Concat(this.Sequence);
                }


                //8 number of outputs to send
                tx_fields = tx_fields.Concat(this.NumTxOut);

                //9 amount to send
                tx_fields = tx_fields.Concat(this.Value);

                //10
                //The script in the old transaction is called scriptPubKey
                //http://bitcoin.stackexchange.com/questions/3374/how-to-redeem-a-basic-tx
                Byte[] outputScriptPubKey = DC.Common.Script.CreateScriptPubKey(destinationHash160);

                Byte outputScriptLen = Convert.ToByte(outputScriptPubKey.Length);
                tx_fields = tx_fields.Concat(outputScriptLen);
                tx_fields = tx_fields.Concat(outputScriptPubKey);

                if (_change > 0)
                {
                    //CHANGE amount
                    tx_fields = tx_fields.Concat(this.Change);

                    //http://bitcoin.stackexchange.com/questions/3374/how-to-redeem-a-basic-tx
                    Byte[] changeScriptPubKey = DC.Common.Script.CreateScriptPubKey(sourceAddress.PublicKeyHash160); //SELF

                    Byte changeScriptLen = Convert.ToByte(changeScriptPubKey.Length);
                    tx_fields = tx_fields.Concat(changeScriptLen);
                    tx_fields = tx_fields.Concat(changeScriptPubKey);
                    //END CHANGE
                }

                //12
                tx_fields = tx_fields.Concat(this.LockTime);

                //13
                tx_fields = tx_fields.Concat(this.HashType);

                //DOUBLE HASH
                Byte[] hash_scriptless = Crypto.DoubleSHA256(tx_fields);

                //SIGN DATA
                Byte[] sig_data = Crypto.Sign(hash_scriptless, sourceAddress.d, DC.Common.Crypto.GetDomainParams());
                sig_data = sig_data.Concat(Convert.ToByte(1));

                //NOW WE HAVE TO APPEND
                //16.We construct the final scriptSig by concatenating: 
                //<One-byte script OPCODE containing the length of the DER-encoded signature plus the one-byte hash code type>
                //|< The actual DER-encoded signature plus the one-byte hash code type>
                //|< One-byte script OPCODE containing the length of the public key>
                //|<The actual public key>

                //Byte[] final_signed = new Byte[1];
                //final_signed[0] = Convert.ToByte(sig_data.Length);
                //final_signed = final_signed.Concat(sig_data);

                //Byte[] pub_key2 = StringHelper.HexStringToByte(destinationHash160);
                //final_signed = final_signed.Concat(Convert.ToByte(pub_key2.Length));
                //final_signed = final_signed.Concat(pub_key2);
                //add to collection
                signedOutPuts.Add(sig_data);
            }

            //final_tx.write_int32(tx_fields['version'])
            //final_tx.write_compact_size(tx_fields['num_txin'])
            //final_tx.write(tx_fields['prevout_hash'])
            //final_tx.write_uint32(tx_fields['output_index'])
            Byte[] final_tx = this.Version;
            Debug.Assert(final_tx[0] == 1);
            Debug.Assert(final_tx.Length == 4);

            final_tx = final_tx.Concat(NumTxIn); //count
            Debug.Assert(final_tx.Length == 5);

            //Outputs to spend
            for (Int32 k = 0; k < _outputsToSpend.Count; k++)
            {
                //hash
                Byte[] previousTxHash = StringHelper.HexStringToByte(_outputsToSpend[k].TxHash);
                final_tx = final_tx.Concat(previousTxHash);

                //index
                Byte[] previousOutputIndex = _outputsToSpend[k].OutputIndexAsBytes;
                Debug.Assert(previousOutputIndex.Length == 4);
                final_tx = final_tx.Concat(previousOutputIndex);

                //add the signed data to the output.  nb,  this could be done in the other loop
                //new script legth
                //16.We construct the final scriptSig by concatenating: 
                //<One-byte script OPCODE containing the length of the DER-encoded signature plus the one-byte hash code type>
                //|< The actual DER-encoded signature plus the one-byte hash code type>
                //|< One-byte script OPCODE containing the length of the public key>
                //|<The actual public key>
                Byte[] final_signed = new Byte[1];
                final_signed[0] = Convert.ToByte(signedOutPuts[k].Length);
                final_signed = final_signed.Concat(signedOutPuts[k]);

                Byte[] pub_key = StringHelper.HexStringToByte(sourceAddress.PublicKeyAsHex);
                final_signed = final_signed.Concat(Convert.ToByte(pub_key.Length));
                final_signed = final_signed.Concat(pub_key);

                //add new signed tx
                final_tx = final_tx.Concat(Convert.ToByte(final_signed.Length));
                final_tx = final_tx.Concat(final_signed);
                final_tx = final_tx.Concat(this.Sequence);
            }

            //##and then we simply write the same data after the scriptSig that is in the signature-less transaction,
            //#  leaving out the four-byte hash code type (as this is encoded in the single byte following the signature data)

            //OUTPUTS
            final_tx = final_tx.Concat(this.NumTxOut);
            final_tx = final_tx.Concat(this.Value);

            Byte[] pub_key_script = DC.Common.Script.CreateScriptPubKey(destinationHash160);
            Byte[] scriptSigFinal = new Byte[1];
            scriptSigFinal[0] = Convert.ToByte(pub_key_script.Length); //Length pub key
            scriptSigFinal = scriptSigFinal.Concat(pub_key_script); //pub key

            final_tx = final_tx.Concat(scriptSigFinal);

            if (_change > 0)
            {
                final_tx = final_tx.Concat(this.Change);
                Byte[] changeScriptPubKey = DC.Common.Script.CreateScriptPubKey(sourceAddress.PublicKeyHash160); //SELF
                final_tx = final_tx.Concat(Convert.ToByte(changeScriptPubKey.Length));
                final_tx = final_tx.Concat(changeScriptPubKey);
            }

            final_tx = final_tx.Concat(this.LockTime);

            return final_tx;
        }
    }
}