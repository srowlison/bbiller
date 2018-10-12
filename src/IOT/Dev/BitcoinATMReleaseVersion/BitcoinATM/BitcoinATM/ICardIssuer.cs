using System;

namespace BitcoinATM
{
    public interface ICardIssuer
    {
        void EjectCard();
        bool Read_IsResetJamSignalOn();

    }
}
