using System;
using System.Net.Mail;
namespace UltimateValidator
{
    /// <summary>Container for the validation algorithms.</summary>
    public struct IsValid
    {
        public static int ToInt(string value) => Convert.ToInt32(value);

        /// <summary>
        /// CNPJ validation algorithm.
        /// </summary>
        /// <param name="CNPJ">String without mask.</param>
        /// <returns>Returns "true" for valid CNPJ, "false" to invalid one.</returns>
        public static bool CNPJ(string CNPJ)
        {
            // helper function
            void UpdateSumAndMult(int length, ref int _sum, ref int _mult)
            {
                for (int i = 0; i < length; i++)
                {
                    _sum += ToInt(CNPJ.Substring(i, 1)) * _mult--;
                    if (_mult == 1) _mult = 9;
                }

            }
            // helper function
            int ResetAuxRest(int _sum)
            {
                int _auxRest = 11 - (_sum % 11);
                if (_auxRest >= 10) return 0;
                return _auxRest;
            }

            if (CNPJ.Length != 14) return false;

            int sum = 0;
            int mult = 5;
            UpdateSumAndMult(12, ref sum, ref mult);

            int auxRest = ResetAuxRest(sum);
            int rest1 = auxRest;

            sum = 0;
            mult = 6;
            UpdateSumAndMult(13, ref sum, ref mult);


            auxRest = ResetAuxRest(sum);
            int rest2 = auxRest;

            int verifyDigitOne = ToInt(CNPJ.Substring(12, 1));
            bool digitOneOk = rest1 == verifyDigitOne;

            int verifyDigitTwo = ToInt(CNPJ.Substring(13, 1));
            bool digitTwoOk = rest2 == verifyDigitTwo;

            return digitOneOk && digitTwoOk;

        }

        /// <summary>
        /// CPF validation algorithm.
        /// </summary>
        /// <param name="CPF">String without mask.</param>
        /// <returns>Returns "true" for valid CPF, "false" to invalid one.</returns>
        public static bool CPF(string CPF)
        {
            // helper function
            bool AreAllCharsTheSame(string value) {
                for (int i = 1; i < value.Length; i++) if (value[i] != value[0]) return false;
                return true;
            }
            // helper function
            int ResetRest(int _sum)
            {
                int _rest = 11 - (_sum % 11);
                if (_rest == 10 || _rest == 11) return 0;
                return _rest;
            }

            if (CPF.Length != 11 || AreAllCharsTheSame(CPF)) return false;

            int sum = 0;
            for (int i = 0; i < 9; i++) sum += ToInt(CPF.Substring(i, 1)) * (10 - i);

            int rest = ResetRest(sum);
            if (rest != ToInt(CPF.Substring(9, 1))) return false;

            sum = 0;
            for (int i = 0; i < 10; i++) sum += ToInt(CPF.Substring(i, 1)) * (11 - i);

            rest = ResetRest(sum);
            if (rest != ToInt(CPF.Substring(10, 1))) return false;

            return true;
        }

        /// <summary>
        /// Specifies if the email parameter is valid.
        /// </summary>
        /// <param name="email">The email to be checked</param>
        /// <returns></returns>
        public static bool Email(string email) {
            try { MailAddress emailAddress = new MailAddress(email); }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Specifies if a given date string is a valid date.
        /// </summary>
        /// <param name="dateTime">The string you want to check.</param>
        /// <returns>"True" for valid date string.</returns>
        public static bool Date(string dateTime) {
            DateTime tmp;
            return DateTime.TryParse(dateTime, out tmp);
        }
    
    }
}