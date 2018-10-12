using System;
using System.Collections.Generic;
using System.Linq;

namespace DC.Common
{
    public class Script
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKeyHash"></param>
        /// <returns></returns>
        public static Byte[] CreateScriptPubKey(String publicKeyHash)
        {
            if (DC.Common.Math.IsHexNumber(publicKeyHash))
            {
                //30440220750503c1c0b599afde192266d54514d822408fde60196be7b24cbdc10584aded02203fdcff061adffb8c5033b34e40fba50d7b94052e64153324460d096eae54c49401 04daf62f77fd142bb33e4bc5df7370151a4f627d0cbf52b4fd7e87caa18e973779f5f0810dc2fc4203e6b45372b28f20e961496ede74e660763c780c40176b08ff
                //"scriptPubKey":"OP_DUP OP_HASH160 dc6e7494a59b426402804ca668f50363b883b1a2 OP_EQUALVERIFY OP_CHECKSIG"
                Byte[] scriptSig = new Byte[3];

                scriptSig[0] = Convert.ToByte(ScriptOp.OP_DUP);
                scriptSig[1] = Convert.ToByte(ScriptOp.OP_HASH160);
                scriptSig[2] = 20; //PUSH DATA Convert.ToByte(0x14);  NB 14 IS HEX
                Byte[] TempSig = StringHelper.HexStringToByte(publicKeyHash);
                scriptSig = scriptSig.Concat(TempSig);
                scriptSig = scriptSig.Concat(Convert.ToByte(ScriptOp.OP_EQUALVERIFY)); //0x88 or 136 in dec
                scriptSig = scriptSig.Concat(Convert.ToByte(ScriptOp.OP_CHECKSIG)); //0xAC  or 172 in dec

                return scriptSig;
            }
            else
            {
                throw new ArgumentException("Public key does not appear to be a hex string");
            }
        }

        /// <summary>
        /// Return the public key from script
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static Byte[] ParseScript(String script)
        {
            //30440220750503c1c0b599afde192266d54514d822408fde60196be7b24cbdc10584aded02203fdcff061adffb8c5033b34e40fba50d7b94052e64153324460d096eae54c49401 04daf62f77fd142bb33e4bc5df7370151a4f627d0cbf52b4fd7e87caa18e973779f5f0810dc2fc4203e6b45372b28f20e961496ede74e660763c780c40176b08ff
            //"scriptPubKey":"OP_DUP OP_HASH160 dc6e7494a59b426402804ca668f50363b883b1a2 OP_EQUALVERIFY OP_CHECKSIG"
            Byte[] scriptSig = new Byte[3];

            scriptSig[0] = Convert.ToByte(ScriptOp.OP_DUP);
            scriptSig[1] = Convert.ToByte(ScriptOp.OP_HASH160);
            scriptSig[2] = 20; //PUSH DATA Convert.ToByte(0x14);  NB 14 IS HEX
            Byte[] TempSig = StringHelper.HexStringToByte(script);
            scriptSig = scriptSig.Concat(TempSig);
            scriptSig = scriptSig.Concat(Convert.ToByte(ScriptOp.OP_EQUALVERIFY)); //0x88 or 136 in dec
            scriptSig = scriptSig.Concat(Convert.ToByte(ScriptOp.OP_CHECKSIG)); //0xAC  or 172 in dec

            return scriptSig;
        }
    }
}
