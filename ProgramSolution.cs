using System.Runtime.CompilerServices;
using System.Text;
using MyExtension;
using System.Text.RegularExpressions;

class ProgramSolution
{
    #region 9월 문제풀이
    /// <summary>
    /// 주사위 놀이 1
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution09172(int a, int b)
    {
        /*
        if ((a % 2 != 0) && (b % 2 != 0))
        {
            return (a * a) + (b * b);
        }
        else if ((a % 2 == 0) && (b % 2 == 0))
        {
            return Math.Abs(a - b);
        }
        else
        {
            return 2 * (a + b);
        }
        */
        int answer = 0;
        int oddCnt = 0;
        if (a % 2 == 1) oddCnt++;
        if (b % 2 == 1) oddCnt++;

        switch (oddCnt)
        {
            case 0: answer = Math.Abs(a - b); break;
            case 1: answer = 2 * (a + b); break;
            case 2: answer = (a * a) + (b * b); break;
        }
        // C# 최신 switch : 프로그래머스에선 사용불가
        // answer = oddCnt switch
        // {
        //     0 => answer = Math.Abs(a - b),
        //     1 => answer = 2 * (a + b),
        //     _ => answer = (a * a) + (b * b)
        // };
        return answer;
    }
    /// <summary>
    /// 배열 비교하기
    /// </summary>
    /// <param name="arr1"></param>
    /// <param name="arr2"></param>
    /// <returns></returns>
    public int Solution0917(int[] arr1, int[] arr2)
    {
        int answer = 0;
        /*
        int sum1 = arr1.Sum();
        int sum2 = arr2.Sum();
        if (arr1.Length > arr2.Length) { answer = 1; }
        else if (arr1.Length < arr2.Length) { answer = -1; }
        else
        {
            if (sum1 > sum2) { answer = 1; }
            else if (sum1 < sum2) { answer = -1; }
        }
        */
        if (arr1.Length > arr2.Length) { answer = 1; }
        else if (arr1.Length < arr2.Length) { answer = -1; }
        else
        {
            // int sum1 = 0;
            // foreach (var item in arr1) { sum1 += item; }
            int sum1 = arr1.Sum();
            int sum2 = arr2.Sum();
            if (sum1 > sum2) answer = 1;
            else if (sum1 < sum2) answer = -1;
            else answer = 0;
        }
        return answer;
    }
    /// <summary>
    /// 배열의 길이에 따라 다른 연산하기
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution09162(int[] arr, int n)
    {
        int len = arr.Length;
        /*
        bool isEven = len % 2 == 0;
        int[] answer = new int[len];
        
        int add = 0;
        for (int i = 0; i < len; i++)
        {
            if (isEven)
            {
                add = i % 2 == 0 ? 0 : n;
            }
            else
            {
                add = i % 2 == 0 ? n : 0;
            }
            answer[i] = arr[i] + add;
        }
        
        // answer = arr;
        // // int i = len % 2 == 0 ? 1 : 0;
        // // int i = 1 - len % 2;
        // for (int i = 1 - len % 2; i < len; i += 2)
        // {
        //     answer[i] = arr[i] + n;
        // }
        // return answer;
        */
        for (int i = 1 - len % 2; i < len; i += 2)
        {
            arr[i] += n;
        }
        return arr;
    }
    /// <summary>
    /// n번째 원소까지
    /// </summary>
    /// <param name="num_list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution0916(int[] num_list, int n)
    {
        /*
        // int[] answer = new int[n];
        // for (int i = 0; i < answer.Length; i++)
        // {
        //     answer[i] = num_list[i];
        // }
        // return answer;
        
        // Array.Resize(ref num_list, n);
        // return num_list;

        // int[] answer = new int[n];
        // Array.Copy(num_list, answer, n);
        // return answer;
        */
        return num_list.Take(n).ToArray();

    }
    /// <summary>
    /// 뒤에서 5등까지
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution09152(int[] num_list)
    {
        const int LENGTH = 5;
        /*
        int[] arr = new int[LENGTH];
        Array.Sort(num_list);
        for (int i = 0; i < LENGTH; i++)
        {
            arr[i] = num_list[i];
        }
        //Array.Copy(num_list, arr, LENGTH);
        return arr;
        */
        var list = new List<int>(num_list);
        list.Sort();
        list.RemoveRange(LENGTH, list.Count - LENGTH);
        return list.ToArray();
    }

    /// <summary>
    /// 문자열을 정수로 변환하기
    /// </summary>
    /// <param name="n_str"></param>
    /// <returns></returns>
    public int Solution0915(string n_str)
    {
        //return int.Parse(n_str);
        return Convert.ToInt32(n_str);
    }

    /// <summary>
    /// 뒤에서 5등 위로
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution09122(int[] num_list)
    {
        // list를 2개 사용해서 실행
        /*
        var list = new List<int>(num_list);
        list.Sort();
        var list2 = new List<int>();
        for (int i = 5; i < list.Count; i++)
        {
            list2.Add(list[i]);
        }
        return list2.ToArray();
        */
        // list의 RemoveAt을 사용 
        var list = new List<int>(num_list);
        list.Sort();
        for (int i = 0; i < 5; i++)
        {
            list.RemoveAt(0);
        }
        return list.ToArray();
    }

    /// <summary>
    /// 문자열 정수의 합
    /// </summary>
    /// <param name="num_str"></param>
    /// <returns></returns>
    public int Solution0912(string num_str)
    {
        int answer = 0;
        foreach (var item in num_str)
        {
            // answer += int.Parse(item.ToString());
            answer += item - '0';
        }
        return answer;
    }
    /// <summary>
    /// 문자열로 변환
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution09112(int n) => $"{n}";
    /*
    {
        // string answer = n.ToString();
        // return "" + n;
        // return string.Format("{0}", n);
        return $"{n}";
    }
    */
    // Solution09112() 메서드를 Expression-bodied 형태로 변경
    public string Solution09113(int n) => n.ToString();

    /// <summary>
    /// 부분 문자열인지 확인하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Solution0911(string my_string, string target)
    {
        // int answer = 0;
        // if (my_string.Contains(target)) answer = 1;
        // return answer;
        // 아래의 방식으로 한줄로 쓸 수 있지만 오히려 보기 어려워지므로 지양할 것.
        // public int Solution0911(string my_string, string target) => my_string.Contains(target) ? 1 : 0;
        // return my_string.Contains(target) ? 1 : 0;
        return my_string.IndexOf(target) < 0 ? 0 : 1;
    }

    /// <summary>
    /// 특별한 이차원 배열 2
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int Solution09102(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] != arr[j, i])
                {
                    return 0;
                }
            }
        }
        return 1;
    }
    /// <summary>
    /// 특별한 이차원 배열 1
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[,] Solution0910(int n)
    {
        int[,] answer = new int[n, n];
        // for (int i = 0; i < n; i++)
        // {
        //     for (int j = 0; j < n; j++)
        //     {
        //         if (i == j)
        //         {
        //             answer[i, j] = 1;
        //         }
        //     }
        // }
        for (int i = 0; i < n; i++)
        {
            answer[i, i] = 1;
        }
        return answer;
    }

    /// <summary>
    /// 0 떼기
    /// </summary>
    /// <param name="n_str"></param>
    /// <returns></returns>
    public string Solution09092(string n_str) => int.Parse(n_str).ToString();
    /*
    {
        // string answer = string.Empty;
        // int num = int.Parse(n_str);
        // answer = num.ToString();
        // return answer;
        // bool isZero = true;
        // while (isZero)
        // {
        //     // if (n_str[0].CompareTo('0') == 0)
        //     if(n_str[0].Equals('0'))
        //     {
        //         n_str = n_str.Substring(1);
        //     }
        //     else
        //     {
        //         isZero = false;
        //         break;
        //     }
        // }
        // return n_str;
        // return int.Parse(n_str).ToString();
    }
    */

    /// <summary>
    /// 부분 문자열
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    public int Solution0909(string str1, string str2)
    {
        return str2.Contains(str1) ? 1 : 0;
    }
    /// <summary>
    /// 꼬리 문자열
    /// </summary>
    /// <param name="str_list"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public string Solution09082(string[] str_list, string ex)
    {
        var sb = new StringBuilder();
        foreach (var item in str_list)
        {
            if (!item.Contains(ex))
            {
                sb.Append(item);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 배열의 원소 삭제하기
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="delete_list"></param>
    /// <returns></returns>
    public int[] Solution0908(int[] arr, int[] delete_list)
    {
        var list = new List<int>();
        foreach (var item in arr)
        {
            if (!delete_list.Contains(item))
            {
                list.Add(item);
            }
        }
        return list.ToArray();
    }
    
    /// <summary>
    /// 정수 찾기
    /// </summary>
    /// <param name="num_list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution09052(int[] num_list, int n)
    {
        int answer = 0;
        foreach (var item in num_list)
        {
            if (item == n)
            {
                answer = 1;
            }
        }
        return answer;

        return num_list.Contains(n) ? 1 : 0;
    }

    /// <summary>
    /// 문자열 바꿔서 찾기
    /// </summary>
    /// <param name="myString"></param>
    /// <param name="pat"></param>
    /// <returns></returns>
    public int Solution0905(string myString, string pat)
    {
        string str = string.Empty;
        // foreach (var item in myString)
        // {
        //     str += item.Equals('A') ? "B" : "A";
        // }
        str = myString.Replace('A', 'b').Replace('B', 'a').ToUpper();
        return str.Contains(pat) ? 1 : 0;
    }
    /// <summary>
    /// 숫자 찾기
    /// </summary>
    /// <param name="num"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int Solution09042(int num, int k)
    {
        // int answer = num.ToString().IndexOf(k.ToString());
        // return (answer == -1) ? answer : answer + 1;
        string str = num.ToString();
        // char kChar = (char)('0' + k);
        char kChar = Convert.ToChar(k.ToString()); // ToChar에 int 값을 넣는 것은 아스키 코드의 인덱스 번호를 넣는 것
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i].Equals(kChar))
            {
                return i + 1;
            }
        }
        return -1;
    }

    /// <summary>
    /// 정수 부분
    /// </summary>
    /// <param name="flo"></param>
    /// <returns></returns>
    public int Solution0904(double flo)
    {
        //answer = (int)flo;
        string[] strArr = flo.ToString().Split('.');
        string str = strArr[0];
        return int.Parse(str);
    }
    /// <summary>
    /// 조건에 맞게 수열 변환하기 3
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] Solution09032(int[] arr, int k)
    {
        int[] answer = new int[arr.Length];
        bool isEven = k % 2 == 0;
        for (int i = 0; i < arr.Length; i++)
        {
            answer[i] = isEven ? arr[i] + k : arr[i] * k;
        }
        return answer;
    }
    /// <summary>
    /// l로 만들기
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public string Solution0903(string myString) => Regex.Replace(myString, "[a-k]", "l");
    /*
    {
        // var sb = new StringBuilder();
        // foreach (var item in myString)
        // {
        //     if (item < 'l' && item >= 'a')
        //     {
        //         sb.Append('l');
        //     }
        //     else
        //     {
        //         sb.Append(item);
        //     }
        // }
        // return sb.ToString();
        return Regex.Replace(myString, "[a-k]", "l");
    }
    */

    /// <summary>
    /// 이어 붙인 수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution09022(int[] num_list)
    {
        int answer = 0;
        string odd = "", even = "";
        foreach (var item in num_list)
        {
            if (item % 2 == 0)
            {
                // even += item.ToString();
                even += item;
            }
            else
            {
                odd += item;
            }
        }
        answer = Int32.Parse(even) + Convert.ToInt32(odd);
        return answer;
    }
    /// <summary>
    /// 특정한 문자를 대문자로 바꾸기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="alp"></param>
    /// <returns></returns>
    public string Solution0902(string my_string, string alp)
    {
        // return my_string.Replace(alp, alp.ToUpper());
        var sb = new StringBuilder();
        foreach (var item in my_string)
        {
            if (item.ToString().Equals(alp))
            {
                // sb.Append(alp.ToUpper());
                sb.Append(alp.ToChangeCase());
            }
            else
            {
                sb.Append(item);
            }
        }
        return sb.ToString();

    }

    public void Solution09012()
    {
        String[] s;

        Console.Clear();
        s = Console.ReadLine().Split(' ');

        int a = Int32.Parse(s[0]);
        int b = Convert.ToInt32(s[1]);

        // Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        Console.WriteLine($"{a} + {b} = {a + b}");
    }

    public void Solution0901()
    {
        string s;
        Console.Clear();
        s = Console.ReadLine();
        foreach (var item in s)
        {
            Console.WriteLine(item);
        }
    }
    #endregion

    #region 8월 문제풀이
    /// <summary>
    /// 주사위 게임 2
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public int Solution08292(int a, int b, int c)
    {
        int answer = 0;
        // 정답
        if (a != b && b != c && a != c)
        {
            answer = a + b + c;
        }
        else if (a == b && b == c)
        {
            answer = (a + b + c) *
                (a * a + b * b + c * c) *
                (a * a * a + b * b * b + c * c * c);
        }
        else
        {
            answer = (a + b + c) * (a * a + b * b + c * c);
        }

        //정답 아님
        /*
        if (a == b || b == c || a == c)
        {
            answer = (a + b + c) * (a * a + b * b + c * c);
        }
        else if (a == b && b == c)
        {
            answer = (a + b + c) *
                (a * a + b * b + c * c) *
                (a * a * a + b * b * b + c * c * c);
        }
        else
        {
            answer = a + b + c;
        }
        */
        return answer;
    }
    /// <summary>
    /// 마지막 두 원소
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution0829(int[] num_list)
    {
        var list = new List<int>(num_list);
        int len = num_list.Length - 1;
        int a = num_list[len] - num_list[len - 1];
        int b = num_list[len] * 2;
        if (num_list[len] > num_list[len - 1])
        {
            list.Add(a);
        }
        else
        {
            list.Add(b);
        }

        return list.ToArray();
        /*
        int len = num_list.Length + 1;
        int[] answer = new int[len];
        for (int i = 0; i < len - 1; i++)
        {
            answer[i] = num_list[i];
        }
        int last1 = num_list[len - 2];
        int last2 = num_list[len - 3];
        if (last1 > last2)
        {
            answer[len - 1] = last1 - last2;
        }
        else
        {
            answer[len - 1] = last1 * 2;
        }
        return answer;
        */
    }
    /// <summary>
    /// 수 조작하기 2
    /// </summary>
    /// <param name="numLog"></param>
    /// <returns></returns>
    public string Solution08282(int[] numLog)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < numLog.Length - 1; i++)
        {
            int num = numLog[i + 1] - numLog[i];
            /*
            if (num == 1)
            {
                sb.Append('w');
            }
            else if (num == -1)
            {
                sb.Append('s');
            }
            else if (num == 10)
            {
                sb.Append('d');
            }
            else
            {
                sb.Append('a');
            }
            */
            switch (num)
            {
                case 1:
                    sb.Append('w');
                    break;
                case -1:
                    sb.Append('s');
                    break;
                case 10:
                    sb.Append('d');
                    break;
                case -10:
                    sb.Append('a');
                    break;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 수 조작하기 1
    /// </summary>
    /// <param name="n"></param>
    /// <param name="control"></param>
    /// <returns></returns>
    public int Solution0828(int n, string control)
    {
        foreach (var item in control)
        {
            switch (item)
            {
                case 'w': n++; break;
                case 's': n--; break;
                case 'd': n += 10; break;
                case 'a': n -= 10; break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        return n;
    }
    /// <summary>
    /// 콜라츠 수열 만들기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution08272(int n)
    {
        var list = new List<int>();
        while (n > 0)
        {
            list.Add(n);
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = n * 3 + 1;
            }
            list.Add(n);
            if (n == 1) break;
        }
        return list.ToArray();
    }

    /// <summary>
    /// 글자 이어 붙여 문자열 만들기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="index_list"></param>
    /// <returns></returns>
    public string Solution0827(string my_string, int[] index_list)
    {
        var sb = new StringBuilder();
        foreach (var item in index_list)
        {
            sb.Append(my_string[item]);
        }
        return sb.ToString();
    }
    /// <summary>
    /// 부분 문자열 이어 붙여 문자열 만들기
    /// </summary>
    /// <param name="my_strings"></param>
    /// <param name="parts"></param>
    /// <returns></returns>
    public string Solution08262(string[] my_strings, int[,] parts)
    {
        var sb = new StringBuilder();
        int cnt = parts.GetLength(0);
        for (int i = 0; i < cnt; i++)
        {
            int len = parts[i, 1] - parts[i, 0] + 1;
            sb.Append(my_strings[i].Substring(parts[i, 0], len));
        }
        return sb.ToString();
    }

    /// <summary>
    /// 접미사 배열
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string[] Solution0826(string my_string)
    {
        int num = my_string.Length - 1;
        var list = new List<string>();
        for (int i = 0; i <= num; i++)
        {
            list.Add(my_string.Substring(num - i));
        }
        list.Sort();
        return list.ToArray();
    }

    /// <summary>
    /// 접두사인지 확인하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="is_prefix"></param>
    /// <returns></returns>
    public int Solution08252(string my_string, string is_prefix)
    {
        /*
        int answer = 1;
        if (is_prefix.Length > my_string.Length)
        {
            return 0;
        }
        for (int i = 0; i < is_prefix.Length; i++)
        {
            if (my_string[i] != is_prefix[i])
            {
                return 0;
            }
        }
        return answer;
        */
        return my_string.IndexOf(is_prefix) == 0 ? 1 : 0;
    }

    /// <summary>
    /// 더 크게 합치기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution0825(int a, int b)
    {
        string ab = $"{a}{b}";
        string ba = $"{b}{a}";
        int iab = int.Parse(ab);
        int iba = Convert.ToInt32(ba);
        int answer = Math.Max(iab, iba);
        return answer;
    }

    public int[] Solution08222(int n, int k)
    {
        var list = new List<int>();
        for (int i = 1, j = i * k; j <= n; i++, j = i * k)
        {
            list.Add(j);
        }
        return list.ToArray();
    }

    /// <summary>
    /// 카운트 다운
    /// </summary>
    /// <param name="start_num"></param>
    /// <param name="end_num"></param>
    /// <returns></returns>
    public int[] Solution0822(int start_num, int end_num)
    {
        /*
        int len = start_num - end_num + 1;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[i] = start_num--;
        }
        return answer;
        */
        var list = new List<int>();
        for (int i = start_num; i >= end_num; i--)
        {
            list.Add(i);
        }
        return list.ToArray();
    }

    public int[] Solution08212(int[] num_list, int n)
    {
        int[] answer = new int[num_list.Length];
        int idx = 0;
        for (int i = n; i < num_list.Length; i++)
        {
            answer[idx++] = num_list[i];
        }
        for (int i = 0; i < n; i++)
        {
            answer[idx++] = num_list[i];
        }
        return answer;
    }
    
    /// <summary>
    /// 첫 번째로 나오는 음수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution0821(int[] num_list)
    {
        for (int i = 0; i < num_list.Length; i++)
        {
            if (num_list[i] < 0)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// n보다 커질 때까지 더하기
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution08202(int[] numbers, int n)
    {
        int answer = 0;
        foreach (var item in numbers)
        {
            answer += item;
            if (answer > n)
            {
                break;
            }
        }
        return answer;
    }

    /// <summary>
    /// 문자열의 뒤의 n글자
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution0820(string my_string, int n)
    {
        // return my_string.Substring(my_string.Length - n, n);
        // return my_string.Remove(0, my_string.Length - n);
        var sb = new StringBuilder();
        int num = my_string.Length - n;
        for (int i = 0; i < my_string.Length; i++)
        {
            if (i < num)
            {
                continue;
            }
            else
            {
                sb.Append(my_string[i]);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 문자열 정렬하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution08192(string my_string)
    {
        char[] chrArray = my_string.ToLower().ToCharArray();
        Array.Sort(chrArray);
        var sb = new StringBuilder();
        foreach (var item in chrArray)
        {
            sb.Append(item);
        }
        return sb.ToString();
    }
    /// <summary>
    /// 가장 큰 수 찾기
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int[] Solution0819(int[] array)
    {
        int[] answer = new int[2];
        /*
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > answer[0])
            {
                answer[0] = array[i];
                answer[1] = i;
            }
        }
        */
        //Dictionary 이용해서 풀이
        var newDic = new Dictionary<int, int>();
        // newDic에 array 값 넣기
        for (int i = 0; i < array.Length; i++)
        {
            newDic.Add(array[i], i);
        }
        var list = new List<int>(array);
        list.Sort();
        answer[0] = list[list.Count - 1];
        answer[1] = newDic[answer[0]];
        return answer;
    }
    /// <summary>
    /// 약수 구하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution080182(int n)
    {
        int[] answer = new int[] { };
        var list = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                list.Add(i);
            }
        }
        answer = list.ToArray();
        return answer;
    }

    /// <summary>
    /// 인덱스 바꾸기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public string Solution0818(string my_string, int num1, int num2)
    {
        /*
        string answer = string.Empty;
        char cs1 = my_string[num1];
        char cs2 = my_string[num2];
        for (int i = 0; i < my_string.Length; i++)
        {
            if (i == num1)
            {
                answer += cs2;
            }
            else if (i == num2)
            {
                answer += cs1;
            }
            else
            {
                answer += my_string[i];
            }
        }
        return answer;
        */
        var sb = new StringBuilder(my_string); // my_string을 가지고 있는 StringBuilder
        sb[num1] = my_string[num2];
        sb[num2] = my_string[num1];
        return sb.ToString();
    }

    public string Solution08142(string my_string)
    {
        var sb = new StringBuilder();
        string answer = string.Empty;
        foreach (var item in my_string)
        {
            // if (item >= 'a' && item <= 'z')
            // {
            //     sb.Append(item.ToString().ToUpper());
            // }
            // else
            // {
            //     sb.Append(item.ToString().ToLower());
            // }
            if (Char.IsLower(item) == true)
            {
                sb.Append(Char.ToUpper(item));
            }
            else
            {
                sb.Append(Char.ToLower(item));
            }
        }
        answer = sb.ToString();
        return answer;
    }

    /// <summary>
    /// flag에 따라 다른 값 반환하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    public int Solution0814(int a, int b, bool flag)
    {
        // if (flag == true) // true와 비교일 경우 생략
        // {
        //     return a + b;
        // }
        // else
        // {
        //     return a - b;
        // }
        return flag ? (a + b) : (a - b);
    }

    /// <summary>
    /// 암호 해독
    /// </summary>
    /// <param name="cipher"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Solution08132(string cipher, int code)
    {
        var sb = new StringBuilder();
        string answer = "";
        for (int i = code - 1; i < cipher.Length; i += code)
        {
            sb.Append(cipher[i]);
        }
        answer = sb.ToString();
        // int index = 0;
        // foreach (var item in cipher)
        // {
        //     if (index % code == code - 1)
        //     {
        //         answer += item.ToString();
        //     }
        //     index++;
        // }
        return answer;
    }

    /// <summary>
    /// n번째 원소부터
    /// </summary>
    /// <param name="num_list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution0813(int[] num_list, int n)
    {
        int len = num_list.Length - n + 1;
        int[] answer = new int[len];
        // for (int i = 0; i < len; i++)
        // {
        //     answer[i] = num_list[n - 1 + i];
        // }
        // num_list의 크기만큼 반복
        for (int i = n - 1, j = 0; i < num_list.Length; i++, j++)
        {
            answer[j] = num_list[i];
        }
        return answer;
    }

    /// <summary>
    /// 홀짝 구분하기
    /// </summary>
    public void Solution08122()
    {
        string[] s;
        Console.Clear();
        s = Console.ReadLine().Split(' ');
        int a = Int32.Parse(s[0]);
        const string str = "{0} is {1}";
        const string strEven = "even";
        const string strOdd = "odd";
        string strVal = (a % 2 == 0) ? strEven : strOdd;
        Console.WriteLine(str, a, strVal);
        // if (a % 2 == 0)
        // {
        //     Console.WriteLine($"{a} is even");
        // }
        // else
        // {
        //     Console.WriteLine($"{a} is odd");
        // }

    }

    /// <summary>
    /// 문자열 곱하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public string Solution0812(string my_string, int k)
    {
        var sb = new StringBuilder();
        string answer = "";
        for (int i = 0; i < k; i++)
        {
            sb.Append(my_string);
        }
        answer = sb.ToString();
        return answer;
    }
    
    /// <summary>
    /// 최댓값 만들기 (2)
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int Solution08112(int[] numbers)
    {
        //int answer = -10000 * 10000;
        int answer = int.MinValue;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int max = numbers[i] * numbers[j];
                // if (answer < max)
                // {
                //     answer = max;
                // }
                answer = Math.Max(answer, max);
            }
        }
        return answer;
    }

    /// <summary>
    /// 숨어있는 숫자 더하기(1)
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution0811(string my_string)
    {
        int answer = 0;
        foreach (var item in my_string)
        {
            // if ((item >= '1') && (item <= 9))
            // {
            //     answer += (item - '0');
            // }
            if (int.TryParse(item.ToString(), out int value))
            {
                answer += value;
            }
        }
        return answer;
    }

    /// <summary>
    /// 문자열 정렬하기(1)
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int[] Solution08082(string my_string)
    {
        var list = new List<int>();
        foreach (var item in my_string)
        {
            if (int.TryParse(item.ToString(), out int value))
            {
                list.Add(value);
            }
        }
        list.Sort();
        return list.ToArray();
    }

    /// <summary>
    /// 주사위의 개수
    /// </summary>
    /// <param name="box"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0808(int[] box, int n)
    {
        // int diceVal = n * n * n;
        // int boxVal = box[0] * box[1] * box[2];
        // int answer = boxVal / diceVal;
        int answer = (box[0] / n) * (box[1] / n) * (box[2] / n);
        return answer;
    }

    /// <summary>
    /// 가위 바위 보
    /// </summary>
    /// <param name="rsp"></param>
    /// <returns></returns>
    public string Solution08072(string rsp)
    {
        const char rsp_Rock = '0';
        const char rsp_Scissors = '2';
        const char rsp_Paper = '5';
        var sb = new StringBuilder();
        string answer = "";
        // for (int i = 0; i < rsp.Length; i++)
        // {
        //     if (rsp[i] == '2')
        //     {
        //         sb.Append("0");
        //     }
        //     else if (rsp[i] == '0')
        //     {
        //         sb.Append("5");
        //     }
        //     else
        //     {
        //         sb.Append("2");
        //     }
        // }
        foreach (var item in rsp)
        {
            if (item == rsp_Rock) sb.Append(rsp_Paper);
            else if (item == rsp_Scissors) sb.Append(rsp_Rock);
            else sb.Append(rsp_Scissors);
        }
        answer = sb.ToString();
        return answer;
    }

    /// <summary>
    /// 공배수
    /// </summary>
    /// <param name="number"></param>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int Solution0807(int number, int n, int m)
    {
        int answer = 0;
        if (number % n == 0 && number % m == 0)
        {
            answer = 1;
        }
        return answer;
    }

    public int Solution08062(int hp)
    {
        int answer = 0;
        int antGeneralAtt = 5; // 장군 개미 공격력
        int antSoldierAtt = 3; // 병정 개미 공격력
        //int antNormalAtt = 1; // 일개미 공격력

        int firstAttack = hp / antGeneralAtt;
        hp %= antGeneralAtt;
        int secondAttack = hp / antSoldierAtt;
        hp %= antSoldierAtt;
        // int lastAttack = hp / antNormalAtt;
        // hp %= antNormalAtt;

        answer = firstAttack + secondAttack + hp;

        return answer;
    }

    /// <summary>
    /// 직각 삼각형 출력하기
    /// </summary>
    public void Solution0806()
    {
        string[] s;
        Console.Clear();
        s = Console.ReadLine().Split(' ');
        int n = Int32.Parse(s[0]); // 잘못 입력했을 경우를 방지
        int n2 = Convert.ToInt32(s[0]);
        int n3 = int.Parse(s[0]);
        char star = '*';

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 문자열의 앞의 n글자
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution08052(string my_string, int n)
    {
        /*
        string answer = "";
        answer = my_string.Substring(0, n);
        return answer;
        */
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(my_string[i]);
        }
        return sb.ToString();
    }

    /// <summary>
    /// n의 배수
    /// </summary>
    /// <param name="num"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0805(int num, int n)
    {
        /*
        if (num % n == 0)
        {
            answer = 1;
        }
        else
        {
            answer = 0;
        }
        */
        int answer = (num % n == 0) ? 1 : 0;
        return answer;
    }

    /// <summary>
    /// 옷가게 할인 받기
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    public int Solution08042(float price)
    {
        if (price >= 100000 && price < 300000)
        {
            price = price * 0.95f;
        }
        else if (price >= 300000 && price < 500000)
        {
            price = price * 0.9f;
        }
        else if (price >= 500000)
        {
            price = price * 0.8f;
        }
        return (int)price;
    }

    /// <summary>
    /// 짝수는 싫어요
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution0804(int n)
    {
        var list = new List<int>();
        for (int i = 0; i <= n; i++)
        {
            if (i % 2 != 0)
            {
                list.Add(i);
            }
        }
        int[] answer = list.ToArray();
        return answer;
    }

    /// <summary>
    /// 중앙값 구하기
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int Solution08012(int[] array)
    {
        int answer = 0;
        var list = new List<int>(array);
        list.Sort();
        int middle = list.Count / 2;
        // Array.Sort(array);
        // answer = array[middle];
        answer = list[middle];
        return answer;
    }
    #endregion

    #region 7월 문제풀이
    /// <summary>
    /// 배열 두배 만들기
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int[] Solution0801(int[] numbers)
    {
        var answer = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            answer[i] = numbers[i] * 2;
        }
        return answer;
    }

    /// <summary>
    /// 중복된 숫자 개수
    /// </summary>
    /// <param name="array"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07312(int[] array, int n)
    {
        int answer = 0;
        foreach (var item in array)
        {
            if (n == item)
            {
                answer++;
            }
        }

        return answer;
    }

    /// <summary>
    /// 문자열 붙여서 출력하기
    /// </summary>
    public void Solution0731()
    {
        String[] input;

        Console.Clear();
        input = Console.ReadLine().Split(' ');

        String s1 = input[0];
        String s2 = input[1];

        var sb = new StringBuilder();
        sb.Append(s1).Append(s2);

        Console.WriteLine(sb);
    }

    /// <summary>
    /// 제곱수 판별하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07302(int n)
    {
        /*
        int answer = 0, min = 1, max = 1000;
        for (int i = min; i <= max; i++)
        {
            if (i * i == n)
            {
                answer = 1;
                break;
            }
            answer = 2;
        }
        return answer;
        */
        double cal = Math.Sqrt(n);

        return (cal % 1 == 0) ? 1 : 2;
    }

    /// <summary>
    /// 문자 리스트를 문자열로 변환하기
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public string Solution0730(string[] arr)
    {
        string answer = "";
        var sb = new StringBuilder();
        foreach (var item in arr)
        {
            sb.Append(item);
        }
        answer = sb.ToString();
        return answer;
    }

    /// <summary>
    /// 문자 반복 출력하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution07292(string my_string, int n)
    {
        string answer = "";
        foreach (var c in my_string)
        {
            answer += new string(c, n);
        }
        return answer;
    }

    /// <summary>
    /// 문자열 안에 문자열
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    public int Solution0729(string str1, string str2)
    {
        int answer = 0;
        if (str1.Contains(str2) == true)
        {
            answer = 1;
        }
        else
        {
            answer = 2;
        }
        return answer;
    }

    /// <summary>
    /// 배열 원소의 길이
    /// </summary>
    /// <param name="strList"></param>
    /// <returns></returns>
    public int[] Solution07282(string[] strList)
    {
        int len = strList.Length;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[i] = strList[i].Length;
        }

        return answer;
    }

    /// <summary>
    /// 아이스 아메리카노
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public int[] Solution0728(int money)
    {
        /*
        int[] answer = new int[2];
        answer[0] = money / 5500;
        answer[1] = money % 5500;
        return answer;
        */
        return new int[] { money / 5500, money % 5500 };
    }
    /// <summary>
    /// n의 배수 고르기
    /// </summary>
    /// <param name="n"></param>
    /// <param name="numlist"></param>
    /// <returns></returns>
    public int[] Solution07252(int n, int[] numlist)
    {
        // 1. 리스트를 만들어서 정의
        var nums = new List<int>();
        // 2. 만든 리스트에 배수(값)을 넣기
        foreach (var item in numlist)
        {
            if (item % n == 0)
            {
                nums.Add(item);
            }
        }
        // 3. answer를 정의 - 길이 설정 필수(여기서 길이는 만든 리스트의 길이)
        int[] answer = new int[nums.Count];
        // 4. answer에 만든 리스트의 값을 넣기
        for (int i = 0; i < nums.Count; i++)
        {
            answer[i] = nums[i];
        }
        return answer;
    }
    
    /// <summary>
    /// 순서쌍의 개수
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07025(int n)
    {
        int answer = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                answer++;
            }
        }
        return answer;
    }

    /// <summary>
    /// 배열의 유사도
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public int Soultion07242(string[] s1, string[] s2)
    {
        int answer = 0;
        /*
        for (int i = 0; i < s1.Length; i++)
        {
            for (int j = 0; j < s2.Length; j++)
            {
                if (s1[i] == s2[j]) answer++;
            }
        }
        */
        foreach (var item in s1)
        {
            foreach (var item2 in s2)
            {
                if (item.Equals(item2))
                //if (item == item2)
                {
                    answer++;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 점의 위치 구하기
    /// </summary>
    /// <param name="dot"></param>
    /// <returns></returns>
    public int Solution0724(int[] dot)
    {
        int a = dot[0], b = dot[1];
        int answer = (a > 0) ? (b > 0) ? 1 : 4 : (b > 0) ? 2 : 3;
        return answer;
        /*
        if (a > 0 && b > 0)
        {
            answer = 1;
        }
        else if (a < 0 && b > 0)
        {
            answer = 2;
        }
        else if (a < 0 && b < 0)
        {
            answer = 3;
        }
        else if (a > 0 && b < 0)
        {
            answer = 4;
        }
        else
        {
            continue;
        }
        */
    }

    /// <summary>
    /// 피자 나눠먹기(3)
    /// </summary>
    /// <param name="slice"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07232(int slice, int n)
    {
        int answer = 0;
        int remain = n % slice == 0 ? 0 : 1;
        answer = (n / slice) + remain;
        // for(int i = 1; i <= n; i += slice)
        // {
        //     answer++;
        // }
        return answer;
    }

    /// <summary>
    /// 배열 자르기
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int[] Solution0723(int[] numbers, int num1, int num2)
    {
        int[] answer = new int[] { };
        int len = num2 - num1 + 1;
        answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[i] = numbers[num1 + i];
        }
        /*
        var list = new List<int>();
        for (int i = num1; i <= num2; i++)
        {
            list.Add(numbers[i]);
        }
        answer = list.ToArray();
        */
        return answer;
    }

    /// <summary>
    /// 삼각형의 완성조건(1)
    /// </summary>
    /// <param name="sides"></param>
    /// <returns></returns>
    public int Soultion07222(int[] sides)
    {
        var list2 = sides.ToList();
        int answer = 0;
        // list
        var list = new List<int>(sides);
        list.Sort();
        answer = (list[2] < list[0] + list[1]) ? 1 : 2;
        // 배열
        // Array.Sort(sides);
        // answer = sides[2] < (sides[0] + sides[1]) ? 1 : 2;

        return answer;
    }

    /// <summary>
    /// 머쓱이보타 키 큰 사람
    /// </summary>
    /// <param name="array"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public int Soultion0722(int[] array, int height)
    {
        int answer = 0;
        /*
        for (int i = 0; i < array.Length; i++)
        {
            if (height < array[i])
            {
                answer++;
            }
        }
        */
        foreach (var item in array)
        {
            if (height < item)
            {
                answer++;
            }
        }
        return answer;
    }
    
    /// <summary>
    /// 자릿수 더하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution07212(int n)
    {
        int answer = 0;
        // n을 string으로 변환
        string sNum = n.ToString();
        // string을 처음부터 반복
        foreach (var item in sNum)
        {
            // answer에 각 char의 계산된 값을 더함
            // answer += int.Parse(item.ToString());
            answer += (item - '0');
        }
        return answer;
    }

    /// <summary>
    /// 모음 제거
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution0721(string my_string)
    {
        //my_string.Replace("a", "").Remove(4).Substring(0, 2); 좋지 않은 코딩
        //my_string.Replace('a', '\0');
        return my_string.Replace("a", "")
            .Replace("e", "")
            .Replace("i", "")
            .Replace("o", "")
            .Replace("u", "");
        /*
        // for, if 사용하는 방법
        string answer = string.Empty;
        for (int i = 0; i < my_string.Length; i++)
        {
            if ((my_string[i] != 'a') &&
                (my_string[i] != 'e') &&
                (my_string[i] != 'i') &&
                (my_string[i] != 'o') &&
                (my_string[i] != 'u'))
            {
                // string의 연산이니 StringBuilder를 사용하자.
                answer += my_string[i];
            }
        }
        return answer;
        */
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