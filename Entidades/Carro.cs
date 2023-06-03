using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorDeEstacionamento.Entidades
{
    internal class Carro
    {
        public string Placa { get; set; }

        public Carro(string placa)
        {
            Placa = placa;
        }

        public override string ToString()
        {
            return $"Placa: {Placa}\n{Estado(Placa)}";
        }


        public string Estado(string licensePlate)
        {
            const string e = "Estado: ";

            //Placas novas:
            const string maranhao_1 = @"^HO[L-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_2 = @"^HP[A-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_3 = @"^HQ[A-E][0-9][A-Z][0-9][0-9]$";
            const string maranhao_4 = @"^NH[A-T][0-9][A-Z][0-9][0-9]$";
            const string maranhao_5 = @"^NM[P-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_6 = @"^NN[A-I][0-9][A-Z][0-9][0-9]$";
            const string maranhao_7 = @"^NW[S-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_8 = @"^NX[A-Q][0-9][A-Z][0-9][0-9]$";
            const string maranhao_9 = @"^OI[R-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_10 = @"^OJ[A-Q][0-9][A-Z][0-9][0-9]$";
            const string maranhao_11 = @"^OX[Q-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_12 = @"^PS[A-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_13 = @"^PT[A-Z][0-9][A-Z][0-9][0-9]$";
            const string maranhao_14 = @"^RO[A-Z][0-9][A-Z][0-9][0-9]$";

            const string ceara_1 = @"^HT[X-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_2 = @"^H[T-Y][A-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_3 = @"^HZA[0-9][A-Z][0-9][0-9]$";
            const string ceara_4 = @"^NQ[L-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_5 = @"^NR[A-E][0-9][A-Z][0-9][0-9]$";
            const string ceara_6 = @"^NU[M-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_7 = @"^NV[A-F][0-9][A-Z][0-9][0-9]$";
            const string ceara_8 = @"^OC[B-U][0-9][A-Z][0-9][0-9]$";
            const string ceara_9 = @"^OH[X-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_10 = @"^OI[A-Q][0-9][A-Z][0-9][0-9]$";
            const string ceara_11 = @"^OR[N-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_12 = @"^OS[A-V][0-9][A-Z][0-9][0-9]$";
            const string ceara_13 = @"^OZA[0-9][A-Z][0-9][0-9]$";
            const string ceara_14 = @"^P[M-O][A-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_15 = @"^RI[A-N][0-9][A-Z][0-9][0-9]$";
            const string ceara_16 = @"^SA[N-Z][0-9][A-Z][0-9][0-9]$";
            const string ceara_17 = @"^SB[A-V][0-9][A-Z][0-9][0-9]$";

            const string piaui_1 = @"^LV[F-Z][0-9][A-Z][0-9][0-9]$";
            const string piaui_2 = @"^LW[A-Q][0-9][A-Z][0-9][0-9]$";
            const string piaui_3 = @"^NH[U-Z][0-9][A-Z][0-9][0-9]$";
            const string piaui_4 = @"^NI[A-X][0-9][A-Z][0-9][0-9]$";
            const string piaui_5 = @"^OD[U-Z][0-9][A-Z][0-9][0-9]$";
            const string piaui_6 = @"^OE[A-I][0-9][A-Z][0-9][0-9]$";
            const string piaui_7 = @"^OU[A-E][0-9][A-Z][0-9][0-9]$";
            const string piaui_8 = @"^OV[W-Y][0-9][A-Z][0-9][0-9]$";
            const string piaui_9 = @"^PI[A-Z][0-9][A-Z][0-9][0-9]$";
            const string piaui_10 = @"^QR[N-Z][0-9][A-Z][0-9][0-9]$";
            const string piaui_11 = @"^RS[G-T][0-9][A-Z][0-9][0-9]$";


            //Placas antigas:
            const string maranhao_1a = @"^HO[L-Z][a-a][0-9][0-9][0-9]$";
            const string maranhao_2a = @"^HP[A-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_3a = @"^HQ[A-E][0-9][0-9][0-9][0-9]$";
            const string maranhao_4a = @"^NH[A-T][0-9][0-9][0-9][0-9]$";
            const string maranhao_5a = @"^NM[P-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_6a = @"^NN[A-I][0-9][0-9][0-9][0-9]$";
            const string maranhao_7a = @"^NW[S-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_8a = @"^NX[A-Q][0-9][0-9][0-9][0-9]$";
            const string maranhao_9a = @"^OI[R-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_10a = @"^OJ[A-Q][0-9][0-9][0-9][0-9]$";
            const string maranhao_11a = @"^OX[Q-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_12a = @"^PS[A-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_13a = @"^PT[A-Z][0-9][0-9][0-9][0-9]$";
            const string maranhao_14a = @"^RO[A-Z][0-9][0-9][0-9][0-9]$";

            const string ceara_1a = @"^HT[X-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_2a = @"^H[T-Y][A-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_3a = @"^HZA[0-9][0-9][0-9][0-9]$";
            const string ceara_4a = @"^NQ[L-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_5a = @"^NR[A-E][0-9][0-9][0-9][0-9]$";
            const string ceara_6a = @"^NU[M-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_7a = @"^NV[A-F][0-9][0-9][0-9][0-9]$";
            const string ceara_8a = @"^OC[B-U][0-9][0-9][0-9][0-9]$";
            const string ceara_9a = @"^OH[X-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_10a = @"^OI[A-Q][0-9][0-9][0-9][0-9]$";
            const string ceara_11a = @"^OR[N-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_12a = @"^OS[A-V][0-9][0-9][0-9][0-9]$";
            const string ceara_13a = @"^OZA[0-9][0-9][0-9][0-9]$";
            const string ceara_14a = @"^P[M-O][A-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_15a = @"^RI[A-N][0-9][0-9][0-9][0-9]$";
            const string ceara_16a = @"^SA[N-Z][0-9][0-9][0-9][0-9]$";
            const string ceara_17a = @"^SB[A-V][0-9][0-9][0-9][0-9]$";

            const string piaui_1a = @"^LV[F-Z][0-9][0-9][0-9][0-9]$";
            const string piaui_2a = @"^LW[A-Q][0-9][0-9][0-9][0-9]$";
            const string piaui_3a = @"^NH[U-Z][0-9][0-9][0-9][0-9]$";
            const string piaui_4a = @"^NI[A-X][0-9][0-9][0-9][0-9]$";
            const string piaui_5a = @"^OD[U-Z][0-9][0-9][0-9][0-9]$";
            const string piaui_6a = @"^OE[A-I][0-9][0-9][0-9][0-9]$";
            const string piaui_7a = @"^OU[A-E][0-9][0-9][0-9][0-9]$";
            const string piaui_8a = @"^OV[W-Y][0-9][0-9][0-9][0-9]$";
            const string piaui_9a = @"^PI[A-Z][0-9][0-9][0-9][0-9]$";
            const string piaui_10a = @"^QR[N-Z][0-9][0-9][0-9][0-9]$";
            const string piaui_11a = @"^RS[G-T][0-9][0-9][0-9][0-9]$";


            bool boolean_M1 = Regex.IsMatch(licensePlate, maranhao_1);
            bool boolean_M2 = Regex.IsMatch(licensePlate, maranhao_2);
            bool boolean_M3 = Regex.IsMatch(licensePlate, maranhao_3);
            bool boolean_M4 = Regex.IsMatch(licensePlate, maranhao_4);
            bool boolean_M5 = Regex.IsMatch(licensePlate, maranhao_5);
            bool boolean_M6 = Regex.IsMatch(licensePlate, maranhao_6);
            bool boolean_M7 = Regex.IsMatch(licensePlate, maranhao_7);
            bool boolean_M8 = Regex.IsMatch(licensePlate, maranhao_8);
            bool boolean_M9 = Regex.IsMatch(licensePlate, maranhao_9);
            bool boolean_M10 = Regex.IsMatch(licensePlate, maranhao_10);
            bool boolean_M11 = Regex.IsMatch(licensePlate, maranhao_11);
            bool boolean_M12 = Regex.IsMatch(licensePlate, maranhao_12);
            bool boolean_M13 = Regex.IsMatch(licensePlate, maranhao_13);
            bool boolean_M14 = Regex.IsMatch(licensePlate, maranhao_14);

            bool boolean_C1 = Regex.IsMatch(licensePlate, ceara_1);
            bool boolean_C2 = Regex.IsMatch(licensePlate, ceara_2);
            bool boolean_C3 = Regex.IsMatch(licensePlate, ceara_3);
            bool boolean_C4 = Regex.IsMatch(licensePlate, ceara_4);
            bool boolean_C5 = Regex.IsMatch(licensePlate, ceara_5);
            bool boolean_C6 = Regex.IsMatch(licensePlate, ceara_6);
            bool boolean_C7 = Regex.IsMatch(licensePlate, ceara_7);
            bool boolean_C8 = Regex.IsMatch(licensePlate, ceara_8);
            bool boolean_C9 = Regex.IsMatch(licensePlate, ceara_9);
            bool boolean_C10 = Regex.IsMatch(licensePlate, ceara_10);
            bool boolean_C11 = Regex.IsMatch(licensePlate, ceara_11);
            bool boolean_C12 = Regex.IsMatch(licensePlate, ceara_12);
            bool boolean_C13 = Regex.IsMatch(licensePlate, ceara_13);
            bool boolean_C14 = Regex.IsMatch(licensePlate, ceara_14);
            bool boolean_C15 = Regex.IsMatch(licensePlate, ceara_15);
            bool boolean_C16 = Regex.IsMatch(licensePlate, ceara_16);
            bool boolean_C17 = Regex.IsMatch(licensePlate, ceara_17);

            bool boolean_P1 = Regex.IsMatch(licensePlate, piaui_1);
            bool boolean_P2 = Regex.IsMatch(licensePlate, piaui_2);
            bool boolean_P3 = Regex.IsMatch(licensePlate, piaui_3);
            bool boolean_P4 = Regex.IsMatch(licensePlate, piaui_4);
            bool boolean_P5 = Regex.IsMatch(licensePlate, piaui_5);
            bool boolean_P6 = Regex.IsMatch(licensePlate, piaui_6);
            bool boolean_P7 = Regex.IsMatch(licensePlate, piaui_7);
            bool boolean_P8 = Regex.IsMatch(licensePlate, piaui_8);
            bool boolean_P9 = Regex.IsMatch(licensePlate, piaui_9);
            bool boolean_P10 = Regex.IsMatch(licensePlate, piaui_10);
            bool boolean_P11 = Regex.IsMatch(licensePlate, piaui_11);

            bool boolean_M1a = Regex.IsMatch(licensePlate, maranhao_1a);
            bool boolean_M2a = Regex.IsMatch(licensePlate, maranhao_2a);
            bool boolean_M3a = Regex.IsMatch(licensePlate, maranhao_3a);
            bool boolean_M4a = Regex.IsMatch(licensePlate, maranhao_4a);
            bool boolean_M5a = Regex.IsMatch(licensePlate, maranhao_5a);
            bool boolean_M6a = Regex.IsMatch(licensePlate, maranhao_6a);
            bool boolean_M7a = Regex.IsMatch(licensePlate, maranhao_7a);
            bool boolean_M8a = Regex.IsMatch(licensePlate, maranhao_8a);
            bool boolean_M9a = Regex.IsMatch(licensePlate, maranhao_9a);
            bool boolean_M10a = Regex.IsMatch(licensePlate, maranhao_10a);
            bool boolean_M11a = Regex.IsMatch(licensePlate, maranhao_11a);
            bool boolean_M12a = Regex.IsMatch(licensePlate, maranhao_12a);
            bool boolean_M13a = Regex.IsMatch(licensePlate, maranhao_13a);
            bool boolean_M14a = Regex.IsMatch(licensePlate, maranhao_14a);

            bool boolean_C1a = Regex.IsMatch(licensePlate, ceara_1a);
            bool boolean_C2a = Regex.IsMatch(licensePlate, ceara_2a);
            bool boolean_C3a = Regex.IsMatch(licensePlate, ceara_3a);
            bool boolean_C4a = Regex.IsMatch(licensePlate, ceara_4a);
            bool boolean_C5a = Regex.IsMatch(licensePlate, ceara_5a);
            bool boolean_C6a = Regex.IsMatch(licensePlate, ceara_6a);
            bool boolean_C7a = Regex.IsMatch(licensePlate, ceara_7a);
            bool boolean_C8a = Regex.IsMatch(licensePlate, ceara_8a);
            bool boolean_C9a = Regex.IsMatch(licensePlate, ceara_9a);
            bool boolean_C10a = Regex.IsMatch(licensePlate, ceara_10a);
            bool boolean_C11a = Regex.IsMatch(licensePlate, ceara_11a);
            bool boolean_C12a = Regex.IsMatch(licensePlate, ceara_12a);
            bool boolean_C13a = Regex.IsMatch(licensePlate, ceara_13a);
            bool boolean_C14a = Regex.IsMatch(licensePlate, ceara_14a);
            bool boolean_C15a = Regex.IsMatch(licensePlate, ceara_15a);
            bool boolean_C16a = Regex.IsMatch(licensePlate, ceara_16a);
            bool boolean_C17a = Regex.IsMatch(licensePlate, ceara_17a);

            bool boolean_P1a = Regex.IsMatch(licensePlate, piaui_1a);
            bool boolean_P2a = Regex.IsMatch(licensePlate, piaui_2a);
            bool boolean_P3a = Regex.IsMatch(licensePlate, piaui_3a);
            bool boolean_P4a = Regex.IsMatch(licensePlate, piaui_4a);
            bool boolean_P5a = Regex.IsMatch(licensePlate, piaui_5a);
            bool boolean_P6a = Regex.IsMatch(licensePlate, piaui_6a);
            bool boolean_P7a = Regex.IsMatch(licensePlate, piaui_7a);
            bool boolean_P8a = Regex.IsMatch(licensePlate, piaui_8a);
            bool boolean_P9a = Regex.IsMatch(licensePlate, piaui_9a);
            bool boolean_P10a = Regex.IsMatch(licensePlate, piaui_10a);
            bool boolean_P11a = Regex.IsMatch(licensePlate, piaui_11a);


            if (boolean_M1 || boolean_M2 || boolean_M3 || boolean_M4 || boolean_M5 || boolean_M6 || boolean_M7
                || boolean_M8 || boolean_M9 || boolean_M10 || boolean_M11 || boolean_M12 || boolean_M13 || boolean_M14 ||
                boolean_M1a || boolean_M2a || boolean_M3a || boolean_M4a || boolean_M5a || boolean_M6a || boolean_M7a
                || boolean_M8a || boolean_M9a || boolean_M10a || boolean_M11a || boolean_M12a || boolean_M13a || boolean_M14a)
            {
                return (e + "Maranhão");
            }
            else if (boolean_C1 || boolean_C2 || boolean_C3 || boolean_C4 || boolean_C5 || boolean_C6 || boolean_C7 || boolean_C8
                || boolean_C9 || boolean_C10 || boolean_C11 || boolean_C12 || boolean_C13 || boolean_C14 ||
                boolean_C15 || boolean_C16 || boolean_C17 || boolean_C1a || boolean_C2a || boolean_C3a || boolean_C4a || boolean_C5a || boolean_C6a
                || boolean_C7a || boolean_C8a || boolean_C9a || boolean_C10a || boolean_C11a ||
                boolean_C12a || boolean_C13a || boolean_C14a || boolean_C15a || boolean_C16a || boolean_C17a)
            {
                return (e + "Ceará");
            }
            else if (boolean_P1 || boolean_P2 || boolean_P3 || boolean_P4 || boolean_P5 || boolean_P6 || boolean_P7 || boolean_P8 || boolean_P9 || boolean_P10 || boolean_P11
                || boolean_P1a || boolean_P2a || boolean_P3a || boolean_P4a || boolean_P5a || boolean_P6a || boolean_P7a || boolean_P8a || boolean_P9a || boolean_P10a || boolean_P11a)
            {
                return (e + "Piauí");
            }
            else
            {
                return "Estado não cadastrado no sistema";
            }

        }

    }
}
