using System.Text;

class ProgramSolution
{
    public string Solution07182(string my_string)
    {
        // 모음 배열을 만든다
        // 모음이 my_string에 있는 것과 비교한다
        string answer = "";

        return answer;
    }

    /// <summary>
    /// 최대값 만들기(1)
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int Solution0718(int[] numbers)
    {
        int answer = 0;
        var list = new List<int>(numbers);
        list.Sort();
        answer = list[list.Count - 1] * list[list.Count - 2];
        /*
        //정렬을 사용하는 방법은 정수가 양수만 있을 때 사용 가능
        
        Array.Sort(numbers);
        Array.Reverse(numbers);
        answer = numbers[0] * numbers[1];
        */

        /*
        var sortedNum = new int[numbers.Length];
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                
                // if (i == j)
                // {
                //     continue;
                // }
                
                // if (answer < numbers[i] * numbers[j]) // answer가 numbers[i] * numbers[j]보다 작을 때 실행
                // {
                //     answer = numbers[i] * numbers[j];
                // }
                
                answer = Math.Max(answer, numbers[i] * numbers[j]);
            }
        }
        */
        return answer;
    }

    #region
    /// <summary>
    /// 세균 증식
    /// </summary>
    /// <param name="n"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public int Solution07172(int n, int t)
    {
        /*
        int answer = 0;
        //Math
        answer = (int)(n * (Math.Pow(2, t)));

        //for문
        for (int i = 0; i < t; i++)
        {
            answer *= 2;
        }
        return answer;
        */
        return n << t;
    }

    /// <summary>
    /// 피자 나눠 먹기(1)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0717(int n)
    {
        int answer = 0;
        int piz = n / 7;
        int res = ((n % 7) == 0) ? 0 : 1;

        answer = piz + res;

        return answer;
    }

    /// <summary>
    /// 뒤집힌 문자열
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution07162(string my_string)
    {
        var list = new List<char>(my_string);
        list.Reverse();
        string answer = new string(list.ToArray());

        /*
            var sb = new StringBuilder();
            foreach (var item in my_string)
            {
                sb.Insert(0, item);
            }
            string answer = sb.ToString();
            */

        /*
        string answer = string.Empty;
        int len = my_string.Length;
        char[] answerArray = new char[len];

        //for / foreach 사용
        for (int i = 0; i < len; i++)
        {
            //위치를 주의해서 배열로 바꾼 answer에 넣자
            answerArray[len - 1 - i] = my_string[i];
        }
        answer = new string(answerArray);
        */

        /*
        var my_strings = my_string.Reverse();
        foreach (var item in my_strings)
        {
            answer += item;
        }
        */
        return answer;

    }

    /// <summary>
    /// 편지
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public int Solution0716(string message)
    {
        int answer = 0;
        answer = 2 * message.Length;
        return answer;
    }

    /// <summary>
    /// 특정 문자 제거하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="letter"></param>
    /// <returns></returns>
    public string Solution07152(string my_string, string letter)
    {
        string answer = string.Empty;
        answer = my_string.Replace(letter, string.Empty);

        //StringBuilder
        /*
        var sb = new StringBuilder();
        foreach (var item in my_string)
        {
            if (item.ToString().CompareTo(letter) != 0)
            {
                sb.Append(item);
            }
        }
        answer = sb.ToString();
        */

        /*
        my_string의 문자열
        for (int i = 0; i < my_string.Length; i++)
        {
            if (my_string[i].ToString() != letter)
            {
                answer += my_string[i];
            }
        }
        */

        /*
        foreach (var item in my_string)
        {
            if (item.ToString() != letter)
            {
                answer += item;
            }
        }
        */
        return answer;
    }

    /// <summary>
    /// 짝수 홀수 개수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution0715(int[] num_list)
    {

        //int[] answer = new int[2];

        var answer = new int[2] { 0, 0 };
        foreach (var item in num_list)
        {
            if (item % 2 == 0)
            {
                answer[0]++;
            }
            else
            {
                answer[1]++;
            }
        }
        /*
        for (int i = 0; i < num_list.Length; i++)
        {
            //값이 짝수인가?
            if (num_list[i] % 2 == 0)
            {
                //answer[0] 값에 +1
                answer[0]++;
            }
            //짝수가 아닌가?
            else
            {
                //answer[1] 값에 +1
                answer[1]++;
            }
        }
        */
        return answer;
    }

    /// <summary>
    /// 배열 뒤집기
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution07142(int[] num_list)
    {
        int len = num_list.Length;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            //answer[len - i - 1] = num_list[i];
            answer[i] = num_list[len - i - 1];

        }
        return answer;
    }

    /// <summary>
    /// 배열의 평균 값
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public float Solution0714(int[] numbers)
    {
        float answer = 0f;
        /*
        //for문을 사용해서 int[]을 돌린다.
        for (int i = 0; i < numbers.Length; i++)
        {
            //answer에 현재 배열 값을 더한다
            answer += numbers[i];
        }
        //더해진 결과 값을 int[]의 길이로 나눈다
        */
        foreach (var item in numbers)
        {
            answer += item;
        }
        answer /= (float)numbers.Length;
        //answer = (float)numbers.Average();

        return answer;
    }
    
    /// <summary>
    /// 짝수의 합
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07112(int n)
    {
        int answer = 0;
        //for문으로 n까지

        for (int i = 1; i <= n; i++)
        {
            //짝수?
            if (i % 2 == 0)
            {
                //짝수이면 answer에 더하기
                answer += i;
            }
        }
        return answer;
    }
    
    /// <summary>
    /// 양꼬치
    /// </summary>
    /// <param name="n">양꼬치</param>
    /// <param name="k">음료수</param>
    /// <returns></returns>
    public int Solution0711(int n, int k)
    {
        int answer = 0;
        int numN = 12000 * n;
        int numK = 2000 * k;
        float serviceK = 0.1f * (float)n;

        answer = numN + numK - ((int)serviceK * 2000);
        return answer;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public int Solution07102(int angle)
    {
        int answer = 3;
        string str = "둔";
        Console.Write(angle + "도는 ");
        if (angle == 90)
        {
            answer = 2;
            str = "직";
        }
        else if (angle == 180)
        {
            answer = 4;
            str = "평";
        }
        else if (angle > 0 && angle < 90)
        {
            answer = 1;
            str = "예";
        }
        // else
        // {
        //     answer = 3;
        //     str = "둔";
        // }
        Console.WriteLine(str + "각입니다");
        /*
        if (angle > 0 && angle < 90)
        {
            answer = 1;
            answerWord = "예각입니다";
        }
        else if (angle == 90)
        {
            answer = 2;
            answerWord = "직각입니다";
        }
        else if (angle > 90 && angle < 180)
        {
            answer = 3;
            answerWord = "둔각입니다";
        }
        else if (angle == 180)
        {
            answer = 4;
            answerWord = "평각입니다";
        }
        */
        return answer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution0710(int num1, int num2)
    {
        int answer = num1 + num2;
        int answer2 = 0;
        answer2 = num2 + num1;
        return answer;
    }

    /// <summary>
    /// 두 수의 나눗셈
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution07092(int num1, int num2)
    {
        int answer = 0;
        // float fnum1 = (float)num1;
        // float fnum2 = (float)num2;
        // float fanswer = 0f;
        // fanswer = fnum1 / fnum2;
        // fanswer *= 1000f

        float temp = (float)num1 / num2 * 1000f;
        answer = (int)temp;
        return answer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    public int Solution0709(int age)
    {
        int nowYear = 2022;
        int answer = nowYear - age + 1;
        return answer;
    }

    /// <summary>
    /// 숫자 비교하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution07082(int num1, int num2)
    {
        if (num1 == num2)
        {
            return 1;
        }
        return -1;

    }

    /// <summary>
    /// 몫 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution0708(int num1, int num2)
    {
        int answer = num1 / num2;
        return answer;
    }

    /// <summary>
    /// 두 수의 곱 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution07072(int num1, int num2)
    {
        int answer = num1 * num2;
        return answer;
    }

    /// <summary>
    /// 두 수의 차 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution0707(int num1, int num2)
    {
        int answer = num1 - num2;
        return answer;
    }

    /// <summary>
    /// 나머지 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int Solution0704(int num1, int num2)
    {
        int answer = num1 % num2;
        return answer;
    }
    #endregion
}