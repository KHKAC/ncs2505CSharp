class ProgramSolution
{

    #region
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
    public int Soultion07112(int n)
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
    public int Soultion0711(int n, int k)
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
    public int Soultion07102(int angle)
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
    public int Soultion0710(int num1, int num2)
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
    public int Soultion07092(int num1, int num2)
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
    public int Soultion0709(int age)
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
    public int Soultion07082(int num1, int num2)
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
    public int Soultion0708(int num1, int num2)
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
    public int Soultion07072(int num1, int num2)
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
    public int Soultion0707(int num1, int num2)
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
    public int Soultion0704(int num1, int num2)
    {
        int answer = num1 % num2;
        return answer;
    }
    #endregion
}