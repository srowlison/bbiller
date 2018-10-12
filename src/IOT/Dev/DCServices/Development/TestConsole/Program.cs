﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinRpcSharp;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BitcoinWallet _wallet = new BitcoinWallet("http://127.0.0.1:8332", "dcuser_node", "JMzipYlSb4VxSC3N7eguTNkkyThE1Luxb1qdxISj", true);
            Decimal balance = _wallet.GetBalance("1N5qam5vqiKobt8QFy2bx5d8kLPU51xhht");

            String tx = _wallet.SendRawTransaction("0100000002c4e646db121146bf0e894d3db8c9846717b79cac525df355a2f82ff1d6211da6010000008b48304502200ec3f9d78e8ba71ea6d9b7ff717f1ed27bbb45379d5d31237fe91b11e965a05c022100bd1f447160fc5927ef8aaf053492199fd73cee103ef5d69b49cecf4936c2fcf6014104a8cbfeacff41f6b04eb5c5cda31d1a75d9febbe20e9f750d519842f0a138d70d9d013207f6ed617840ad9f78b667e986c7b90f0708f4f44395aa1f4f69bf631cffffffff1f060effe001471ae8cbcc88f4748e7ae88723f1299ced6c8b31fbaf98ab32c5000000008b483045022064ec164a4f2cea955ea103cafeae056526035ede198e166c5d0c533c80a66bda022100e1c37a3ba64a89cb1c297ccc2dd6547ee3b0874794b1629012d485b9475f0c36014104a8cbfeacff41f6b04eb5c5cda31d1a75d9febbe20e9f750d519842f0a138d70d9d013207f6ed617840ad9f78b667e986c7b90f0708f4f44395aa1f4f69bf631cffffffff02c95bbd00000000001976a914d0acbaa610e441aef23937866345ef8512640c2788ac80969800000000001976a914e20134d6a50e4f4f9519109aa9c4395bee61887088ac00000000");

            //const String PRIVATE_KEY_AS_DEC2 = "56264673822963068407370790525340191907437491654303176136090258467429147271236";
            //srLocal.AtmClient localClient = new srLocal.AtmClient();

            //localClient.SendBitcoins2(PRIVATE_KEY_AS_DEC2, "1DugongACGcyyvvgvcy8skYyezsx5jy3aV", 0.001M);

            localClient.SendBitcoins2(PRIVATE_KEY_AS_DEC2, "1DugongACGcyyvvgvcy8skYyezsx5jy3aV", 0.0001M);

            String gc = "01000000020BA61AB58CF807E091515BDA6CC3B58E47A5702A53AFB90126E2376E1AD4FE9E000000008B4830450221008C8C0A7D0B813992F9E443E12DA2B1C4CCE72604757483B5AC8CF4089CF6365202206F3C67D01EBA34D9E8450E8FAC39D089A119BF8C16D8F02FA02785ED7D829F7E014104A8CBFEACFF41F6B04EB5C5CDA31D1A75D9FEBBE20E9F750D519842F0A138D70D9D013207F6ED617840AD9F78B667E986C7B90F0708F4F44395AA1F4F69BF631CFFFFFFFFDB7C5C3C2011CEE5B4402FEDD03BA0B37566B905CA49857ACF97C10D33438415000000008A47304402201DD98389E5A59E7F2E5AC8F4E2D359472CCD3E25C2256E458A712BB0A734AF9D02204E03FDF5B675DC154E44CD1848B30DC6F273EA8D6C72EB1A7456740520653C17014104A8CBFEACFF41F6B04EB5C5CDA31D1A75D9FEBBE20E9F750D519842F0A138D70D9D013207F6ED617840AD9F78B667E986C7B90F0708F4F44395AA1F4F69BF631CFFFFFFFF01706F9800000000001976A914B769ACCEE57C332F74B18A133CAEE9B283285A4688AC00000000";
            //string sk = "01000000020BA61AB58CF807E091515BDA6CC3B58E47A5702A53AFB90126E2376E1AD4FE9E000000008B48304502206BDD05C4741DC75B7087F0FCD8BC2DFC7A19A0E3A203A60F49D98B601950767D022100AED6E4CF8F4AD4AAC00EB58B7B9D505AA81087A80AF2002CE8C37EA652B71583014104A8CBFEACFF41F6B04EB5C5CDA31D1A75D9FEBBE20E9F750D519842F0A138D70D9D013207F6ED617840AD9F78B667E986C7B90F0708F4F44395AA1F4F69BF631CFFFFFFFFDB7C5C3C2011CEE5B4402FEDD03BA0B37566B905CA49857ACF97C10D33438415000000008B48304502203A8D7173F83EC95DEED64A30926EE9F42F20C1F53FAD3631F8E9841093B17E4F022100C27CE4561872A3735796926C4309CC71D7E772BBB0338140F3F903F238624058014104A8CBFEACFF41F6B04EB5C5CDA31D1A75D9FEBBE20E9F750D519842F0A138D70D9D013207F6ED617840AD9F78B667E986C7B90F0708F4F44395AA1F4F69BF631CFFFFFFFF01706F9800000000001976A91407BDEC596751A706C76C8F110E27E7F6F2AB5ECE88AC00000000";

            //var trans =_wallet.DecodeRawTransaction(gc);

            String txn = _wallet.SendRawTransaction(gc);

            Console.WriteLine(txn);
            Console.ReadKey();
        }
    }
}
