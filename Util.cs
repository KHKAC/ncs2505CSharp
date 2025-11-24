namespace Hagoon
{
    class Util
    {
        // n개에서 m개 뽑는 방법의 수(순서 상관 없음)
        public static double Combi(int n, int m)
        {
            return Factorial(n) / (Factorial(n - m) * Factorial(m));
        }

        // 팩토리얼 값 구하기
        public static double Factorial(int n)
        {
            double f = 1;
            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }

        /// <summary>
        /// 최소 공배수
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int LCM(int n, int m)
        {
            return n * m / GCD(n, m);
        }

        /// <summary>
        /// 최대 공약수
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int GCD(int n, int m)
        {
            if (m == 0)
            {
                return n;
            }
            else
            {
                return n % m != 0 ? GCD(m, n % m) : m;
            }
        }

        public delegate int CompareDelegate(int i1, int i2);
        // Util에 있는 CompareDelegate와 동일한 Prototype
        public static int AscendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i2 - i1) > 0 ? 1 : -1;
        }
        // Util에 있는 CompareDelegate와 동일한 Prototype
        public static int DecendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i1 - i2) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 오름차순 / 내림차순
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="comp"></param>
        public static void Sort(int[] arr, CompareDelegate comp)
        {
            if (arr.Length < 2) return;
            // Console.WriteLine("함수 Prototype" + comp.Method);

            int ret;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    ret = comp(arr[i], arr[j]);
                    if (ret == -1)
                    {
                        int tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
            // PrintArray(arr);
        }
        /// <summary>
        /// 사칙연산 계산기
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="calcType"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException"></exception>
        public static int Calc(int a, int b, string calcType = "+")
        {
            switch (calcType)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                default:
                    throw new ArithmeticException();
            }
        }

        /// <summary>
        /// 정수 배열의 합을 구하는 함수
        /// </summary>
        /// <param name="scoreArray"></param>
        /// <returns></returns>
        public static int CalculateSum(int[] scoreArray) //배열 받는쪽 
        {
            int sum = 0;
            for (int i = 0; i < scoreArray.Length; i++)
            {
                sum += scoreArray[i];
            }
            return sum;
        }


        // 정수 배열을 출력시키는 함수
        /*
        public static void PrintIntArray(int[] answerArray)
        {
            Console.Write("[ ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                Console.Write(answerArray[i]);
                if (i != answerArray.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" ]");
        }
        */

        /// <summary>
        /// 배열을 출력시키는 함수
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="answerArray"></param>
        public static void PrintArray<T>(T[] answerArray)
        {
            Console.Write("[ ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                Console.Write(answerArray[i]);
                if (i != answerArray.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" ]");
        }

        /// <summary>
        /// 로또 번호 만들기 (나중에 필요하니 삭제 X)
        /// </summary>
        public static void MakeLotto()
        {
            //상수
            const int TOTAL_BALLS = 45; //전체 공 개수
            const int PICK_BALLS = 6; // 뽑는 공 개수

            //랜덤 함수 선언 필요
            var random = new Random();
            //볼이 담긴 리스트 선언
            var ballList = new List<int>();
            //리스트에 볼 45개 넣기
            for (int i = 1; i <= TOTAL_BALLS; i++)
            {
                ballList.Add(i);
            }
            //리스트에서 볼을 하나씩 6번 꺼내기
            for (int i = 0; i < PICK_BALLS; i++)
            {
                //남아있는 볼 갯수 중 랜덤하게 인덱스 고르기
                int index = random.Next() % ballList.Count;
                //[인덱스]와 볼 번호 출력
                Console.Write("[" + index + "] ");
                Console.WriteLine(ballList[index]);
                //인덱스에 있는 볼을 리스트에서 지우기
                ballList.RemoveAt(index);
            }
        }
    }
}