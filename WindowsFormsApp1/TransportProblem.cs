using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TransportProblem
    {
        class InvalidInpFormat : ApplicationException
        {
            public InvalidInpFormat() : base() { }
            public InvalidInpFormat(string str) : base(str) { }
            public override string ToString()
            {
                return Message;
            }
        }
        // склады
        public float[] mA;
        // потребители
        public float[] mB;
        // Издержки
        public float[,] mC;

        public int ASize;
        public int BSize;

        // Конструкторы
        public TransportProblem(float[] nA, float[] nB, float[,] nC)
        {
            if ((nA.Length != nC.GetLength(0)) || (nB.Length != nC.GetLength(1)))
                throw new InvalidInpFormat("Размеры массива затрат не соответствуют размерам массивов поставщиков и складов");
            this.mA = nA; this.mB = nB; this.mC = nC;
            this.ASize = nA.Length; this.BSize = nB.Length;
        }
        public TransportProblem(int _Asize, int _Bsize, string sA, string sB, string[] sC)
        {
            ASize = _Asize; BSize = _Bsize;
            float x = 0;
            string[] StrArr = sA.Split(' ');
            if (StrArr.Length != ASize)
                throw new InvalidInpFormat("Размеры массива А не соответствуют заявленным");
            mA = new float[ASize];
            for (int i = 0; i < mA.Length; i++) if (float.TryParse(StrArr[i], out x)) mA[i] = x;

            StrArr = sB.Split(' ');
            if (StrArr.Length != BSize)
                throw new InvalidInpFormat("Размеры массива B не соответствуют заявленным");
            mB = new float[BSize];
            for (int i = 0; i < mB.Length; i++) if (float.TryParse(StrArr[i], out x)) mB[i] = x;

            float sumA = 0;
            Array.ForEach(mA, delegate (float f) { sumA += f; });
            float sumB = 0;
            Array.ForEach(mB, delegate (float f) { sumB += f; });
            float dif = sumA - sumB;
            if (dif > 0)
            {
                float[] bufArr = mB;
                mB = new float[bufArr.Length + 1];
                bufArr.CopyTo(mB, 0);
                mB[mB.Length - 1] = Math.Abs(dif);
                BSize++;
            }
            else if (dif < 0)
            {
                float[] bufArr = mA;
                mA = new float[bufArr.Length + 1];
                bufArr.CopyTo(mA, 0);
                mA[mA.Length - 1] = Math.Abs(dif);
                ASize++;
            }

            mC = new float[ASize, BSize];
            for (int j = 0; j < sC.Length; j++)
            {
                StrArr = sC[j].Split(' ');
                if (StrArr.Length != _Bsize)
                    throw new InvalidInpFormat("Длина одной из строк входного файла не соответствует длине массива В");
                for (int i = 0; i < _Bsize; i++) if (float.TryParse(StrArr[i], out x)) mC[j, i] = x;
            }
        }
        // Строим опорные планы тут
        bool isEmpty(float[] arr)
        {
            return Array.TrueForAll(arr, delegate (float x) { return x == 0; });
        }

        private void NanToEmpty(float[,] outArr)
        {
            int i = 0, j = 0;
            for (i = 0; i < ASize; i++)
                for (j = 0; j < BSize; j++)
                    if (outArr[i, j] == 0) outArr[i, j] = float.NaN;
        }

        float findMin(float[,] Arr, bool[,] pr, out int indi, out int indj)
        {
            indi = -1; indj = -1;
            float min = float.MaxValue;
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                    if ((pr[i, j]) && (Arr[i, j] < min))
                    {
                        min = Arr[i, j];
                        indi = i; indj = j;
                    }
            return min;
        }

        // Метод северо-западного угла
        public float[,] NordWest()
        {
            float[] Ahelp = mA;
            float[] Bhelp = mB;
            int i = 0, j = 0;
            float[,] outArr = new float[ASize, BSize];
            NanToEmpty(outArr);
            //МЯСО
            while (!(isEmpty(Ahelp) && isEmpty(Bhelp)))
            {
                float Dif = Math.Min(Ahelp[i], Bhelp[j]);
                outArr[i, j] = Dif;
                Ahelp[i] -= Dif; Bhelp[j] -= Dif;
                if ((Ahelp[i] == 0) && (Bhelp[j] == 0) && (j + 1 < BSize)) outArr[i, j + 1] = 0;
                if (Ahelp[i] == 0) i++;
                if (Bhelp[j] == 0) j++;
            }
            return outArr;
        }
        // Метод минимального элемента
        public float[,] MinEl()
        {
            float[] Ahelp = this.mA;
            float[] Bhelp = this.mB;
            int i = 0;
            int j = 0;
            float min = float.MaxValue;
            float[,] outArr = new float[this.ASize, this.BSize];
            bool[,] pArr = new bool[this.ASize, this.BSize];
            for (i = 0; i < this.ASize; i++)
            {
                for (j = 0; j < this.BSize; j++)
                {
                    pArr[i, j] = true;
                }
            }
            i = 0;
            j = 0;
            int k;
            int count = 0;
            while (!this.isEmpty(Ahelp) || !this.isEmpty(Bhelp))
            {
                min = this.findMin(this.mC, pArr, out i, out j);
                float Dif = Math.Min(Ahelp[i], Bhelp[j]);
                outArr[i, j] += Dif; count++;
                Ahelp[i] -= Dif;
                Bhelp[j] -= Dif;
                if (Ahelp[i] == 0f)
                {
                    k = 0;
                    while (k < this.BSize)
                    {
                        pArr[i, k] = false;
                        k++;
                    }
                }
                if (Bhelp[j] == 0f)
                {
                    for (k = 0; k < this.ASize; k++)
                    {
                        pArr[k, j] = false;
                    }
                }
            }
            this.NanToEmpty(outArr);

            int difference = (ASize + BSize - 1) - count;
            for (int l = 0; l < difference; l++)
            {
                //выбираем непустые
                Allowed = new Point[count + 1];
                k = 0;
                for (i = 0; i < ASize; i++)
                    for (j = 0; j < BSize; j++)
                        if (outArr[i, j] == outArr[i, j])
                        {
                            Allowed[k] = new Point(i, j);
                            k++;
                        }
                // ищем куда загрузить
                bool p = true;
                Point Nl = new Point(0, 0);
                for (i = 0; (i < ASize) && p; i++)
                    for (j = 0; (j < BSize) && p; j++)
                    {
                        Nl = Allowed[9] = new Point(i, j);
                        FindWay fw = new FindWay(i, j, true, Allowed, new Point(i, j), null);
                        p = fw.BuildTree();
                    }
                if (!p) outArr[Nl.X, Nl.Y] = 0;
            }

            return outArr;
        }
        class FindWay
        {
            FindWay Father;
            Point Root;
            FindWay[] Childrens;
            Point[] mAllowed;
            Point Begining;
            //true - вниз/вверх
            //false - влево/вправо
            bool flag;
            public FindWay(int x, int y, bool _flag, Point[] _mAllowed, Point _Beg, FindWay _Father)
            {
                Begining = _Beg;
                flag = _flag;
                Root = new Point(x, y);
                mAllowed = _mAllowed;
                Father = _Father;
            }
            public Boolean BuildTree()
            {
                Point[] ps = new Point[mAllowed.Length];
                int Count = 0;
                for (int i = 0; i < mAllowed.Length; i++)
                    if (flag)
                    {
                        if (Root.Y == mAllowed[i].Y)
                        {
                            Count++;
                            ps[Count - 1] = mAllowed[i];
                        }

                    }
                    else
                        if (Root.X == mAllowed[i].X)
                    {
                        Count++;
                        ps[Count - 1] = mAllowed[i];
                    }

                FindWay fwu = this;
                Childrens = new FindWay[Count];
                //Point[] ss = new Point[mAllowed.Length];
                int k = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (ps[i] == Root) continue;
                    if (ps[i] == Begining)
                    {
                        while (fwu != null)
                        {
                            mAllowed[k] = fwu.Root;
                            fwu = fwu.Father;
                            k++;
                        };
                        for (; k < mAllowed.Length; k++) mAllowed[k] = new Point(-1, -1);
                        return true;
                    }

                    if (!Array.TrueForAll<Point>(ps, p => ((p.X == 0) && (p.Y == 0))))
                    {
                        Childrens[i] = new FindWay(ps[i].X, ps[i].Y, !flag, mAllowed, Begining, this);
                        Boolean result = Childrens[i].BuildTree();
                        if (result) return true;
                    }
                }
                return false;
            }

        }

        // Оптимизация методом потенциалов
        private void FindUV(float[] U, float[] V, float[,] HelpMatr)
        {
            bool[] U1 = new bool[ASize];
            bool[] U2 = new bool[ASize];
            bool[] V1 = new bool[BSize];
            bool[] V2 = new bool[BSize];

            while (!(AllTrue(V1) && AllTrue(U1)))
            {
                int i = -1;
                int j = -1;
                for (int i1 = BSize - 1; i1 >= 0; i1--)
                    if (V1[i1] && !V2[i1]) i = i1;
                for (int j1 = ASize - 1; j1 >= 0; j1--)
                    if (U1[j1] && !U2[j1]) j = j1;

                if ((j == -1) && (i == -1))
                    for (int i1 = BSize - 1; i1 >= 0; i1--)
                        if (!V1[i1] && !V2[i1])
                        {
                            i = i1;
                            V[i] = 0;
                            V1[i] = true;
                            break;
                        }
                if ((j == -1) && (i == -1))
                    for (int j1 = ASize - 1; j1 >= 0; j1--)
                        if (!U1[j1] && !U2[j1])
                        {
                            j = j1;
                            U[j] = 0;
                            U1[j] = true;
                            break;
                        }

                if (i != -1)
                {
                    for (int j1 = 0; j1 < ASize; j1++)
                    {
                        if (!U1[j1]) U[j1] = HelpMatr[j1, i] - V[i];
                        if (U[j1] == U[j1]) U1[j1] = true;
                    }
                    V2[i] = true;
                }

                if (j != -1)
                {
                    for (int i1 = 0; i1 < BSize; i1++)
                    {
                        if (!V1[i1]) V[i1] = HelpMatr[j, i1] - U[j];
                        if (V[i1] == V[i1]) V1[i1] = true;
                    }
                    U2[j] = true;
                }

            }
            int rt = 0;
        }

        private bool AllPositive(float[,] m)
        {
            bool p = true;
            for (int i = 0; (i < ASize) && p; i++)
                for (int j = 0; (j < BSize) && p; j++)
                    if (m[i, j] < 0) p = false;
            return p;
        }

        private bool AllTrue(bool[] arr)
        {
            return Array.TrueForAll(arr, delegate (bool x) { return x; });
        }

        // дозаполняет матрицу S оценками
        private float[,] MakeSMatr(float[,] M, float[] U, float[] V)
        {

            float[,] HM = new float[ASize, BSize];
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                {
                    HM[i, j] = M[i, j];
                    if (HM[i, j] != HM[i, j])
                        HM[i, j] = mC[i, j] - (U[i] + V[j]);
                }
            return HM;
        }

        private Point[] Allowed;// хранит координаты клеток, в которых есть груз

        public int[] arra = new int[5];

        private Point[] GetCycle(int x, int y)
        {
            Point Beg = new Point(x, y);
            FindWay fw = new FindWay(x, y, true, Allowed, Beg, null);
            fw.BuildTree();
            Point[] Way = Array.FindAll<Point>(Allowed, delegate (Point p) { return (p.X != -1) && (p.Y != -1); });
            return Way;
        }

        // находит плохой цикл и крутит его
        private void Roll(float[,] m, float[,] sm)
        {
            Point minInd = new Point();
            float min = float.MaxValue;
            int k = 0;
            Allowed = new Point[ASize + BSize];
            for (int i = 0; i < ASize; i++)
                for (int j = 0; j < BSize; j++)
                {
                    if (m[i, j] == m[i, j])
                    {
                        Allowed[k].X = i;
                        Allowed[k].Y = j;
                        k++;
                    }
                    if (sm[i, j] < min)
                    {
                        min = sm[i, j];
                        minInd.X = i;
                        minInd.Y = j;
                    }
                }
            // Ищем цикл
            Allowed[Allowed.Length - 1] = minInd;
            Point[] Cycle = GetCycle(minInd.X, minInd.Y);
            float[] Cycles = new float[Cycle.Length];
            bool[] bCycles = new bool[Cycle.Length];
            for (int i = 0; i < bCycles.Length; i++)
                bCycles[i] = i == bCycles.Length - 1 ? false : true;
            min = float.MaxValue;

            for (int i = 0; i < Cycle.Length; i++)
            {
                Cycles[i] = m[Cycle[i].X, Cycle[i].Y];
                if ((i % 2 == 0) && (Cycles[i] == Cycles[i]) && (Cycles[i] < min))
                {
                    min = Cycles[i];
                    minInd = Cycle[i];
                }
                if (Cycles[i] != Cycles[i]) Cycles[i] = 0;
            }
            int point1 = 0;

            for (int i = 0; i < Cycle.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Cycles[i] -= min;
                    m[Cycle[i].X, Cycle[i].Y] -= min;
                }
                else
                {
                    Cycles[i] += min;
                    if (m[Cycle[i].X, Cycle[i].Y] != m[Cycle[i].X, Cycle[i].Y]) m[Cycle[i].X, Cycle[i].Y] = 0;
                    m[Cycle[i].X, Cycle[i].Y] += min;
                }
            }
            m[minInd.X, minInd.Y] = float.NaN;
        }

        public float[,] PotenMeth(float[,] SupArr)
        {
            int i = 0, j = 0;
            float[,] HelpMatr = new float[ASize, BSize];
            for (i = 0; i < ASize; i++)
                for (j = 0; j < BSize; j++)
                    if (SupArr[i, j] == SupArr[i, j]) HelpMatr[i, j] = mC[i, j];
                    else HelpMatr[i, j] = float.NaN;

            //расчёт
            float[] U = new float[ASize];
            float[] V = new float[BSize];
            FindUV(U, V, HelpMatr);
            float[,] SMatr = MakeSMatr(HelpMatr, U, V);
            while (!AllPositive(SMatr))
            {
                Roll(SupArr, SMatr);
                for (i = 0; i < ASize; i++)
                    for (j = 0; j < BSize; j++)
                    {
                        if (SupArr[i, j] == float.PositiveInfinity)
                        {
                            HelpMatr[i, j] = mC[i, j];
                            SupArr[i, j] = 0;
                            continue;
                        }
                        if (SupArr[i, j] == SupArr[i, j]) HelpMatr[i, j] = mC[i, j];
                        else HelpMatr[i, j] = float.NaN;
                    }
                FindUV(U, V, HelpMatr);
                SMatr = MakeSMatr(HelpMatr, U, V);
            }

            return SupArr;
        }
    }
}
