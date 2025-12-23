using System.Runtime.CompilerServices;
using Hagoon;
using System.Text;
using MyExtension;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics.Tracing;
using System.Diagnostics;

class ProgramSolution
{
    #region 12월 문제풀이
    /// <summary>
    /// 옹알이(1)
    /// </summary>
    /// <param name="babbling"></param>
    /// <returns></returns>
    public int Solution1223(string[] babbling)
    {
        int answer = 0;
        string str = "";
        
        for(int i = 0; i < babbling.Length; i++)
        {
            babbling[i] = babbling[i].Replace("aya", "x");
            babbling[i] = babbling[i].Replace("ye", "x"); 
            babbling[i] = babbling[i].Replace("woo", "x");
            babbling[i] = babbling[i].Replace("ma", "x");
            str = babbling[i].Replace("x", string.Empty);
            if(str == "")
            {
                answer++;
            }           
        }
        return answer;
        
    }

    /// <summary>
    /// 숫자 문자열과 영단어
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int Solution1223(string s)
    {
        s = s.Replace("zero", "0")
            .Replace("one", "1")
            .Replace("two", "2")
            .Replace("three", "3")
            .Replace("four", "4")
            .Replace("five", "5")
            .Replace("six", "6")
            .Replace("seven", "7")
            .Replace("eight", "8")
            .Replace("nine", "9");

        return int.Parse(s);

    }

    public int[,] Solution12222(int n)
    {
        int[,] answer = new int[n,n];
        int count = 1;
        int idX = 0;
        int idY = 0;
        do
        {
            // left -> right
            for(int i = 0; i < n; i++)
            {
                answer[idX, idY + i] = count + i;
            }
            // up -> down
            count += n - 1;
            idY += n - 1;
            for(int i = 0; i < n; i++)
            {
                answer[idX + i, idY] = count + i;
            }
            // right -> left
            count += n - 1;
            idX += n - 1;
            for(int i = 0; i < n; i++)
            {
                answer[idX, idY - i] = count + i;
            }
            // down -> up
            count += n - 1;
            idY -= n - 1;
            for(int i = 0; i < n - 1; i++)
            {
                answer[idX - i, idY] = count + i;
            }
            // 정리
            count += n - 1;
            n -= 2;
            idX -= n;
            idY++;
        } while (n > 0);
        return answer;
    }

    /// <summary>
    /// 시저 암호
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution1222(string s, int n)
    {
        /*
        char[] charArray = s.ToCharArray();
        
        for(int i = 0; i < charArray.Length; i++)
        {
            if(char.IsLetter(charArray[i]))
            {
                char baseChar = char.IsUpper(charArray[i]) ? 'A' : 'a';
                charArray[i] = (char)(((charArray[i] - baseChar + n) % 26) + baseChar);
            }
        }
        return new string(charArray);
        */
        var sb = new StringBuilder();
        foreach(var item in s)
        {
            char chr = ' ';
            if(!item.Equals(chr))
            {
                if(char.IsUpper(item))
                {
                    chr = Convert.ToChar((item + n - 'A') % 26 + 'A');
                }
                else
                {
                    chr = Convert.ToChar((item + n - 'a') % 26 + 'a');
                }
            }
            sb.Append(chr);
        }
        return sb. ToString();
    }

    /// <summary>
    /// 평행
    /// </summary>
    /// <param name="dots"></param>
    /// <returns></returns>
    public int Solution12192(int[,] dots)
    {
        if ((double)(dots[0, 0] - dots[1, 0]) / (dots[0, 1] - dots[1, 1]) == (double)(dots[2, 0] - dots[3, 0]) / (dots[2, 1] - dots[3, 1]))
        {
            return 1;
        }
        if ((double)(dots[0, 0] - dots[2, 0]) / (dots[0, 1] - dots[2, 1]) == (double)(dots[1, 0] - dots[3, 0]) / (dots[1, 1] - dots[3, 1]))
        {
            return 1;
        }
        if ((double)(dots[0, 0] - dots[3, 0]) / (dots[0, 1] - dots[3, 1]) == (double)(dots[1, 0] - dots[2, 0]) / (dots[1, 1] - dots[2, 1]))
        {
            return 1;
        }

        return 0;
    }

    /// <summary>
    /// 수박수박수박수박수박수?
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public string Solution1219(int n)
    {
        var sb = new StringBuilder();
        for(int i = 0; i < n; i++)
        {
            sb.Append((i % 2 == 0) ? "수" : "박");
        }
        return sb.ToString();
    }

    public int Solution12182(int[,] lines)
    {
        int answer = 0;

        int[] dots = new int[201];

        for(int i = 0; i < 3; i++)
        {
            for(int k = lines[i,0]; k < lines[i,1]; k++){
                dots[k + 100]++;
            }
        }

        for(int i = 0; i < 201; i++)
        {
            if(dots[i] > 1){
                answer++;
            }
        }

        return answer;
    }

    /// <summary>
    /// 핸드폰 번호 가리기
    /// </summary>
    /// <param name="phone_number"></param>
    /// <returns></returns>
    public string Solution1218(string phone_number)
    {
        var sb = new StringBuilder();
        for(int i = 0; i < phone_number.Length; i++)
        {
            if(i < phone_number.Length - 4)
            {
                sb.Append('*');
            }
            else
            {
                sb.Append(phone_number[i]);
            }
        }
        return sb.ToString();
    }
    
    /// <summary>
    /// 주사위 게임 3
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public int Solution12172(int a, int b, int c, int d)
    {
        /*
        int[] dice = { a, b, c, d };

        // 등장 횟수 세기
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        foreach (int x in dice)
        {
            if (cnt.ContainsKey(x))
                cnt[x]++;
            else
                cnt[x] = 1;
        }

        int kinds = cnt.Count; // 서로 다른 눈의 개수

        // 1. 네 개가 모두 같은 경우 (p p p p)
        if (kinds == 1)
        {
            int p = dice[0];
            return 1111 * p;
        }

        // 2. 서로 다른 숫자가 2개인 경우
        if (kinds == 2)
        {
            foreach (var kv in cnt)
            {
                if (kv.Value == 3)
                {
                    int p = kv.Key;
                    int q = cnt.Keys.First(x => x != p);
                    int val = 10 * p + q;
                    return val * val;
                }
            }

            var keys = cnt.Keys.ToArray();
            int p2 = keys[0];
            int q2 = keys[1];
            return (p2 + q2) * Math.Abs(p2 - q2);
        }

        // 3. 서로 다른 숫자가 3개인 경우 (p p q r)
        if (kinds == 3)
        {
            List<int> ones = new List<int>();
            int two = 0;

            foreach (var kv in cnt)
            {
                if (kv.Value == 2)
                    two = kv.Key;
                else
                    ones.Add(kv.Key); // 1번씩 나온 눈들
            }

            return ones[0] * ones[1];
        }

        // 4. 모두 다른 경우 (kinds == 4)
        return dice.Min();
        */
        int answer = 0;
        // 주사위 눈을 인덱스로 하는 배열 정의
        int[] dice = new int[7];
        // 주사위 배열에 값을 더하는 함수 호출
        dice[a]++;
        dice[b]++;
        dice[c]++;
        dice[d]++;
        // 4개가 모두 같은 숫자인 경우
        if(dice.Contains(4))
        {
            for(int p = 1; p <= 6; p++)
            {
                if(dice[p] == 4)
                {
                    answer = 1111 * p;
                    break;
                }
            }
        }
        else if(dice.Contains(3)) // 3 - 1
        {
            for(int p = 1; p <= 6; p++)
            {
                if(dice[p] == 3)
                {
                    for(int q = 1; q <= 6; q++)
                    {
                        if(dice[q] == 1)
                        {
                            answer = (10 * p + q) * (10 * p + q);
                            break;
                        }
                    }
                }
            }
        }
        else if(dice.Contains(2)) // 2
        {
            if(dice.Contains(1)) // 2 - 1 - 1
            {
                // p를 구할 필요가 없다.
                for(int q = 1; q <= 6; q++)
                {
                    if(dice[q] == 1)
                    {
                        for(int r = q + 1; r <= 6; r++)
                        {
                            if(dice[r] == 1)
                            {
                                answer = q * r;
                                break;
                            }
                        }
                    }
                }
            }
            else // 2 - 2
            {
                for(int p = 1; p <= 6; p++)
                {
                    if(dice[p] == 2)
                    {
                        for(int q = p + 1; q <= 6; q++)
                        {
                            if(dice[q] == 2)
                            {
                                // q는 p보다 크다
                                answer = (p + q) * (q - p);
                                break;
                            }
                        }
                    }
                }
            }
        }
        else // 1 - 1 - 1 - 1
        {
            answer = 6;
            for(int i = 1; i <= 6; i++)
            {
                if(dice[i] == 1 && (answer > i))
                {
                    answer = i;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 콜라츠 추측
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution1217(int n)
    {
        int answer = 0;
        long num = n;
        for(int i = 0; i <= 500; i++)
        {
            if(num == 1)
            {
                return i;
            }
            num = num % 2 == 0 ? num / 2 : num * 3 + 1;
        }
        answer = -1;
        return answer;
    }

    /// <summary>
    /// 안전지대
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public int Solution12152(int[,] board)
    {
         int answer = 0;
        int len = board.GetLength(0);
            int [,] temp = new int [len+2, len+2];
            for(int x = 1; x <= len; x++)
            {
                for(int y = 1; y <= len; y++)
                {
                    if(board[x - 1, y - 1] == 1)
                    {
                        temp[x - 1, y - 1]++;
                        temp[x - 1, y]++;
                        temp[x - 1, y + 1]++;
                        temp[x, y - 1]++;
                        temp[x, y]++;
                        temp[x, y + 1]++;
                        temp[x + 1, y - 1]++;
                        temp[x + 1, y]++;
                        temp[x + 1, y + 1]++;

                    }
                }
            }
            for(int x = 1; x <= len; x++)
            {
                for(int y = 1; y <= len; y++)
                {
                    if (temp[x, y] == 0)
                    {
                        answer++;
                    }
                }
            }
        return answer;
    }

    /// <summary>
    /// 두 정수 사이의 합
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public long Solution1215(int a, int b)
    {
        int answer = 0;
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        for(int i = min; i <= max; i++)
        {
            answer += i;
        }
        return Convert.ToInt64(answer);
    }
    /// <summary>
    /// 연속된 수의 합
    /// </summary>
    /// <param name="num"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    public int[] Solution12122(int num, int total)
    {
        // answer 배열을 생성
        int[] answer = new int[num];
        // total을 num으로 나눈 인덱스 변수 생성
        int idx = total / num;
        // 인덱스의 처음 시작 위치 조정
        idx = idx - ((num - 1) / 2);
        // for문 num만큼 반복
        for(int i = 0; i < num; i++)
        {
            // answer 배열에 값 넣기
            answer[i] = idx + i;
        }
        return answer;
    }

    /// <summary>
    /// 다음에 올 숫자
    /// </summary>
    /// <param name="common"></param>
    /// <returns></returns>
    public int Solution1212(int[] common)
    {
        int answer = 0;
        int len = common.Length;
        for(int i = 0; i < len; i++)
        {
            int a = common[0];
            int b = common[1];
            int c = common[2];
            if((c - b) == (b - a))
            {
                answer = common[len - 1] + (b - a);
            }
            else
            {
                answer = common[len - 1] * (b / a);
            }
        }
        return answer;
    }
    /// <summary>
    /// 최빈값 구하기
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int Solution12112(int[] array)
    {
        var dic = new Dictionary<int,int>();
        foreach (var item in array)
        {
            if(dic.ContainsKey(item))
            {
                dic[item]++;
            }
            else
            {
                dic.Add(item, 1);
            }
        }
        if(dic.Count == 1)
        {
            // return dic.Keys.ToArray()[0];
            return array[0];
        }
        int[] arr = new int[dic.Count];
        int idx = 0;
        foreach(var item in dic)
        {
            arr[idx] = item.Value;
            idx++;
        }
        Array.Sort(arr);
        if(arr[arr.Length - 1] == arr[arr.Length - 2])
        {
            return -1;
        }
        foreach (var item in dic)
        {
            if(arr[arr.Length - 1] == item.Value)
            {
                return item.Key;
            }
        }
        return -1;
    }

    /// <summary>
    /// OX 퀴즈
    /// </summary>
    /// <param name="quiz"></param>
    /// <returns></returns>
    public string[] Solution1211(string[] quiz)
    {
        string[] answer = new string[quiz.Length];
        for(int i = 0; i < quiz.Length; i++)
        {
            string[] sArr = quiz[i].Split(" ");
            int a = int.Parse(sArr[0]);
            int b = int.Parse(sArr[2]);
            int c = int.Parse(sArr[4]);
            string d = sArr[1];
            if(d.Equals("-"))
            {
                answer[i] = a - b == c ? "O" : "X";
            }
            else
            {
                answer[i] = a + b == c ? "O" : "X";
            }
        }
        return answer;
    }

    /// <summary>
    /// 하샤드 수
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool Solution12102(int x)
    {
        string xStr = x.ToString();
        int sum = 0;
        foreach(var item in xStr)
        {
            sum += item - '0';
        }
        if(x % sum == 0) return true;
        else return false;
    }

    /// <summary>
    /// 문자열 출력하기
    /// </summary>
    public void Solution1210()
    {
        string s;
        Console.Clear();
        s = Console.ReadLine();
        Console.WriteLine(s);
    }
    /// <summary>
    /// 다항식 더하기
    /// </summary>
    /// <param name="polynomial"></param>
    /// <returns></returns>
    public string Solution12092(string polynomial)
    {
        // 문자열 계산이므로 StringBuilder 사용
        var sb = new StringBuilder();
        // 주어진 다항식을 분리
        string[] sArr = polynomial.Split(" + ");
        // 필요한 변수들 선언
        int xNum = 0, num = 0, xTotal = 0, total = 0;
        // 분리된 배열의 크기만큼 순회
        foreach(var item in sArr)
        {
            // 'x'를 포함하고 있으면
            if(item.Contains('x'))
            {
                // 크기가 1이면 값도 1
                if(item.Length == 1)
                {
                    xNum = 1;
                }
                // 아니면 값만 떼어서 계산
                else
                {
                    xNum = int.Parse(item.Remove(item.Length -1));
                }
                xTotal += xNum;
            }
            else
            {
                num = int.Parse(item);
                total += num;
            }
            
        }
        // 'x'변수가 0이 아니면
        if(xTotal != 0)
        {
            sb.Append(xTotal == 1 ? "x" : $"{xTotal}x");
        }
        // 상수 변수가 0이 아니면
        if(total != 0)
        {
            if(xTotal != 0) sb.Append(" + ");
            sb.Append(total);
        }
        return sb.ToString();
    }

    /// <summary>
    /// 배열 조각하기
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public int[] Solution1209(int[] arr, int[] query)
    {
        // 인덱스 변수 정의
        int idx = 0;
        // query를 순회
        foreach(var item in query)
        {
            // 인덱스가 짝수면
            if(idx % 2 == 0)
            {
                //arr의 크기 조정
                Array.Resize(ref arr, item + 1);
            }
            else
            {
                // arr의 임시 배열 정의
                int[] temp = arr;
                // arr의 크기 조정
                Array.Resize(ref arr, arr.Length - item);
                // arr에 값 넣기
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = temp[i + item];
                }
            }
            // 인덱스 증가
            idx++;
        }
        return arr;
    }

    /// <summary>
    /// 특이한 정렬
    /// </summary>
    /// <param name="numlist"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution12082(int[] numlist, int n)
    {
        //i는 두번째 요소부터 마지막까지 순회
        for (int i = 1; i < numlist.Length; i++)
        {
            // 첫번째부터 i까지 순회
            for(int j = 0; j < i + 1; j++)
            {
                // i for문에서 n까지의 절대값
                int iAbs = Math.Abs(numlist[i] - n);
                // j for문에서 n까지의 절대값
                int jAbs = Math.Abs(numlist[j] - n);
                // 두 값을 비교
                if(iAbs < jAbs)
                {
                    //두 값을 교환
                    int temp = numlist[j];
                    numlist[j] = numlist[i];
                    numlist[i] = temp;
                }
                // 두 값이 같을 경우
                else if(iAbs == jAbs)
                {
                    if(numlist[i] > numlist[j])
                    {
                        //두 값을 교환
                        int temp = numlist[j];
                        numlist[j] = numlist[i];
                        numlist[i] = temp;
                    }
                }
            }
        }
        return numlist;
    }

    /// <summary>
    /// 코드 처리하기
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Solution1208(string code)
    {
        var sb = new StringBuilder();
        // mode, idx 변수 만들기
        bool mode = false;
        int idx = 0;
        // code를 순회하면서
        foreach (var item in code)
        {
            //item이 1인경우 모드 체인지
            if(item.Equals('1'))
            {
                mode = !mode;
                idx++;
                continue;
            }
            // mode의 값에 따라
            if(mode == false)
            {
                // idx의 값에 따라
                if(idx % 2 == 0)
                {
                    sb.Append(item);
                }
            }
            else
            {
                //idx의 값에 따라
                if(idx % 2 != 0)
                {
                    sb.Append(item);
                }
            }
            idx++;
        }
        // 리턴 값이 없을 경우
        if(sb.ToString().Length == 0)
        {
            return "EMPTY";
        }
        return sb.ToString();;
    }
    /// <summary>
    /// 유한소수 판별하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution12052(int a, int b)
    {
        // 기약분수로 만들기 (a/b에서 b를 gcd로 나눔)
        int gcd = Util.GCD(a, b);
        b /= gcd;

        // 분모에서 2 제거
        while (b % 2 == 0)
        {
            b /= 2;
        }
        // 분모에서 5 제거
        while (b % 5 == 0)
        {
            b /= 5;
        }
        // 모두 제거하고 1이면 유한소수, 아니면 무한소수
        return (b == 1) ? 1 : 2;
    }
    
    /// <summary>
    /// 배열 만들기 2
    /// </summary>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public int[] Solution1205(int l, int r)
    {
        int[] answer;
        var list = new List<int>();

        /*
        for (int i = l; i <= r; i++) 
        {
            string s = i.ToString();
            bool isCorrect = true;

            foreach (char c in s)
            {
                if (c != '0' && c != '5')
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect) list.Add(i);
        }

        if (list.Count == 0) return new int[] { -1 };

        return list.ToArray();
        */
        for (int i = l; i <= r; i++)
        {
            if(i % 5 != 0) continue;
            string str = i.ToString();
            if(str.Replace("0","").Replace("5","").Length == 0)
            {
                list.Add(i);
            }
        }
        answer = list.ToArray();
        if(list.Count == 0)
        {
            answer = new int[]{-1};
        }
        return answer;
    }
    /// <summary>
    /// 문자열 밀기
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    public int Solution12042(string A, string B)
    {
        /*
        for (int i = 0; i < A.Length; i++)
        {
            A = A.Substring(A.Length - 1, 1) + A.Substring(0, A.Length - 1);
            if(A.Equals(B))
            {
                return i + 1;
            }
        }
        return -1;
        */
        // A와 B가 같다면 바로 0 리턴
        if(A.Equals(B)) return 0;
        // A의 크기 -1만큼 반복 (한번 밀었다고 가정해야하니 i는 1부터 시작)
        for (int i = 1; i < A.Length; i++)
        {
            // A를 밀기
            A = StringPush(A);
            // A와 B를 비교
            if(A.Equals(B))
            {
                // 같다면 현재 인덱스를 리턴
                return i;
            }
        }
        // 여기까지 왔다면 -1 리턴
        return -1;
    }
    // string을 오른쪽으로 밀기
    string StringPush(string A)
    {
        var sb = new StringBuilder();
        // string의 크기를 변수로 잡고
        int cnt = A.Length;
        // 마지막 글자를 얻어와서
        string last = A.Substring(cnt - 1, 1);
        string remain = A.Substring(0, cnt -1);
        // 맨 앞에 넣고
        sb.Append(last);
        sb.Append(remain);
        // 리턴
        return sb.ToString();
    }

    /// <summary>
    /// 저주의 숫자 3
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution1204(int n)
    {
        int answer = 0;
        // n만큼 반복
        for (int i = 0; i < n; i++)
        {
            // 특정조건(3을 포함하거나 3으로 나누어 떨어질 때)만 건너뛰기
            do // 0부터 시작이니 처음 한번은 무조건 실행할 수 있도록
            {
                answer++;
            } while(answer % 3 == 0 || answer.ToString().Contains("3"));
        }
        return answer;
    }

    /// <summary>
    /// 등수 매기기
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public int[] Solution12032(int[,] score)
    {
        // 등수를 담을 리스트 선언
        var answer = new List<int>();
        // 합산 점수를 담을 리스트 선언
        var sum = new List<int>();
        // 합산 점수 리스트에 값 채우기
        for (int i = 0; i < score.GetLength(0); i++)
        {
            // 합산 값으로
            sum.Add(score[i,0] + score[i,1]);
        }
        // 내림차순으로 정렬해서 새로운 리스트에 넣는다.
        var newList = sum.OrderByDescending(x => x).ToList();
        // 순회
        for (int i = 0; i < newList.Count; i++)
        {
            // 정렬된 리스트에서의 인덱스를 찾아 등수 매기기
            // 먼저 찾아지는 인덱스로 공동 등수를 처리
            int rank = newList.FindIndex(x => x == sum[i]) + 1;
            answer.Add(rank);
        }
        // 배열형으로 변환한 것을 반환
        return answer.ToArray();
    }
    
    /// <summary>
    /// 치킨 쿠폰
    /// </summary>
    /// <param name="chicken"></param>
    /// <returns></returns>
    public int Solution1203(int chicken)
    {
        int answer = 0;
        int coupon = chicken;
        while(coupon >= 10)
        {
            coupon -= 10;
            answer++;
            coupon++;
        }
        return answer;
    }

    /// <summary>
    /// 직사각형 넓이 구하기
    /// </summary>
    /// <param name="dots"></param>
    /// <returns></returns>
    public int Solution12022(int[,] dots)
    {
        // 가로, 세로로 사용할 변수
        int w = 0, h = 0;
        // 첫번째 x좌표 = 두번째 x좌표
        if(dots[0,0] == dots[1,0])
        {
            h = Math.Abs(dots[0,1] - dots[1,1]);
            w = Math.Abs(dots[0,0] - dots[2,0]);
        }
        else if(dots[0,0] == dots[2,0])
        {
            h = Math.Abs(dots[0,1] - dots[2,1]);
            w = Math.Abs(dots[0,0] - dots[1,0]);
        }
        else
        {
            h = Math.Abs(dots[0,1] - dots[3,1]);
            w = Math.Abs(dots[0,0] - dots[1,0]);
        }
        return w * h;
    }

    /// <summary>
    /// 대소문자 바꿔서 출력하기
    /// </summary>
    public void Solution1202()
    {
        string s;
        Console.Clear();
        s = Console.ReadLine();
        var sb = new StringBuilder();
        foreach(var item in s)
        {
            if(item >= 'a' && item <= 'z')
            {
                sb.Append(item.ToString().ToUpper());
            }
            else if(item >= 'A' && item <= 'Z')
            {
                sb.Append(item.ToString().ToLower());
            }
        }
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// 로그인 성공?
    /// </summary>
    /// <param name="id_pw"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    public string Solution12012(string[] id_pw, string[,] db)
    {
        string answer = string.Empty;
        for(int i = 0; i < db.GetLength(0); i++)
        {
            if(id_pw[0] == db[i,0])
            {
                if(id_pw[1] == db[i,1])
                {
                    answer = "login";
                }
                else
                {
                    answer = "wrong pw";
                }
                break;
            }
            else
            {
                answer = "fail";
            }
        }
        return answer;
    }

    /// <summary>
    /// 전국 대회 선발 고사
    /// </summary>
    /// <param name="rank"></param>
    /// <param name="attendance"></param>
    /// <returns></returns>
    public int Solution1201(int[] rank, bool[] attendance)
    {
        int answer = 0;
        // 등수와 인덱스를 가진 dictionary 선언
        var dic = new Dictionary<int, int>();
        // 등수만 가진 list
        var list = new List<int>(rank);
        // 등수 크기만큼 순회
        for (int i = 0; i < rank.Length; i++)
        {
            // dictionary에 넣고
            dic.Add(rank[i], i);
            // 불참이면
            if(attendance[i] == false)
            {
                // list에 rank최대값 넣고
                list[i] = list.Count + 1;
            }
        }
        // list 정렬
        list.Sort();
        // 마지막 값 계산
        answer = dic[list[0]] * 10000 + dic[list[1]] * 100 + dic[list[2]];
        return answer;
    }
    #endregion

    #region 11월 문제풀이
    /// <summary>
    /// 정사각형으로 만들기
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[,] Solution11282(int[,] arr)
    {
        // arr 배열의 행,열 중 큰 수를 찾는다
        int xLen = arr.GetLength(0);
        int ylen = arr.GetLength(1);
        int len = Math.Max(xLen, ylen);
        // 찾아진 큰 수만큼의 정사각형 배열을 만든다
        int[,] answer = new int[len, len];
        // 기본 값인 0이 다 들어가있다.
        // arr을 순회하면서 answer에 넣는다
        // 정확히 넣어야할 위치가 필요하므로 foreach가 아닌 for 사용
        for (int x = 0; x < xLen; x++)
        {
            for (int y = 0; y < ylen; y++)
            {
                answer[x,y] = arr[x,y];
            }
        }
        return answer;
    }

    /// <summary>
    /// 외계어 사전
    /// </summary>
    /// <param name="spell"></param>
    /// <param name="dic"></param>
    /// <returns></returns>
    public int Solution1128(string[] spell, string[] dic)
    {
        // 단어가 존재할 때 바로 1을 리턴하면 되므로 없을 때 2를 리턴하는 것을 기본으로 한다
        // int answer = 2;
        // dic을 순회하면서
        foreach (var item in dic)
        {
            // spell의 길이가 검사는 각 항목의 길이보다, 큰 경우 바로 다음으로
            if(item.Length < spell.Length) continue;
            // spell의 각 항목을 검사하기 위한 list를 선언
            var list = new List<string>(spell);
            // item을 char별로 순회하면서
            foreach (char c in item)
            {
                // list에 있는 경우 list에서 삭제
                if(list.Contains(c.ToString()))
                {
                    list.Remove(c.ToString());
                }
            }
            // list의 크기가 0이면 1을 리턴
            if(list.Count == 0) return 1;
        }
        // 여기까지 왔다면 단어가 없는 것이므로 2리턴
        return 2;
    }

    /// <summary>
    /// 문자열 겹쳐쓰기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="overwrite_string"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public string Solution11262(string my_string, string overwrite_string, int s)
    {
        // Remove, Insert
        // return my_string.Remove(s, overwrite_string.Length).Insert(s, overwrite_string);
        
        // Substring
        /*
        var sb = new StringBuilder();
        sb.Append(my_string.Substring(0,s));
        sb.Append(overwrite_string);
        sb.Append(my_string.Substring(s + overwrite_string.Length));
        return sb.ToString();
        */
        var sb = new StringBuilder();
        sb.Append(my_string.Take(s).ToArray());
        sb.Append(overwrite_string);
        sb.Append(my_string.Skip(s + overwrite_string.Length).ToArray());
        return sb.ToString();
    }

    /// <summary>
    /// a와 b 출력하기
    /// </summary>
    public void Solution1126()
    {
        Console.Clear();
        string[] s = Console.ReadLine().Split(' ');
        Console.WriteLine($"a = {s[0]}\nb = {s[1]}");
    }

    /// <summary>
    /// 그림 확대
    /// </summary>
    /// <param name="picture"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public string[] Solution11252(string[] picture, int k)
    {
        // 확대 전 원본 그림
        foreach (var item in picture)
        {
            Console.WriteLine(item);
        }
        //x값 구하기
        int x = picture.Length;
        // 반환 그림의 크기만큼 answer를 잡는다
        string[] answer = new string[x * k];
        // 인덱스 값 하나 잡고
        int idx = 0;
        // string형의 변수 하나 잡고 => StringBuilder 사용
        var sb = new StringBuilder();
        
        foreach(string s in picture)
        {
            sb.Clear();
            // picture의 string 하나를 다시 char 별로 순회
            foreach(char c in s)
            {
                for(int i = 0; i < k; i++)
                {
                    sb.Append(c);
                }
            }
            //k 만큼 반복
            for (int i = 0; i < k; i++)
            {
                answer[idx * k + i] = sb.ToString();
            }
            idx++;
        }
        foreach(var item in answer)
        {
            Console.WriteLine(item); 
        }
        return answer;

        /*
        string[] result = new string[picture.Length];
        
        for(int i = 0; i < picture.Length; i++)
        {
            char[] arr = picture[i].ToCharArray();
            {
                for (int j = 0; j < arr.Length;j++)
                {
                    for(int z = 0; z < k; z++)
                    {
                        result[i] += arr[j];
                    }
                }
            }
        }
        List<string> res= new List<string>();
        for(int y = 0; y < result.Length; y++)
        {
            for(int s = 0; s < k; s++)
            {
                res.Add(result[y]);
            }
        }
        return res.ToArray();
        */
    }

    /// <summary>
    /// 삼각형의 완성 조건(2)
    /// </summary>
    /// <param name="sides"></param>
    /// <returns></returns>
    public int Solution1125(int[] sides)
    {
        int a = sides.Max() - sides.Min();
        int b = sides.Max() + sides.Min();
        int answer = b - a - 1;
        return answer;
        
    }
    
    /// <summary>
    /// 구슬을 나누는 경우의 수
    /// </summary>
    /// <param name="balls"></param>
    /// <param name="share"></param>
    /// <returns></returns>
    public int Solution11242(int balls, int share)
    {
        // double temp = Util.Combi(balls, share);
        // int answer = Convert.ToInt32(temp);
        return Convert.ToInt32(Util.Combi(balls, share));
    }
    /*
    double Sol(int n, int m)
    {
        return Factorial(n) / (Factorial(n - m) * Factorial(m));
    }
    double Factorial(int n)
    {
        double f = 1;
        for(int i = 2; i <= n; i++)
        {
            f *= i;
        }
        return f;
    }
    */

    //
    public int[] Solution1124(int[] arr, int k)
    {
        int[] answer = new int[k];
        for(int i = 0; i < k; i++)
        {
            answer[i] = -1;
        }

        var hs = new HashSet<int>();
        int idx = 0;
        foreach (var item in arr)
        {
            if(hs.Contains(item))
            {
                continue;
            }
            else
            {
                answer[idx] = item;
                hs.Add(item);
                idx++;
                if(idx == k) break;
            }
        }
        return answer;
    }
    
    /// <summary>
    /// 영어가 싫어요
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public long Solution1121(string numbers)
    {
        long answer = 0;
        return answer;
    }

    /// <summary>
    /// 문자열 계산하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution11192(string my_string)
    {
        int answer = 0;
        var str = my_string.Split(" ");
        int pm = 1;
        foreach (var item in str)
        {
            int temp = 0;
            if(item.Equals("+"))
            {
                pm = 1;
            }
            else if(item.Equals("-"))
            {
                pm = -1;
            }
            else
            {
                temp = int.Parse(item);
            }
            answer += temp * pm;
        }
        return answer;
    }
    
    /// <summary>
    /// 문자열 여러번 뒤집기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public string Solution1119(string my_string, int[,] queries)
    {
        char[] answer = my_string.ToCharArray();
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            int s = queries[i, 0];
            int e = queries[i, 1] - queries[i, 0] + 1;

            Array.Reverse(answer, s, e);
        }
        return new string(answer);
    }
    
    /// <summary>
    /// 이진수 더하기
    /// </summary>
    /// <param name="bin1"></param>
    /// <param name="bin2"></param>
    /// <returns></returns>
    public string Solution11182(string bin1, string bin2)
    {
        int int1 = Convert.ToInt32(bin1, 2);
        int int2 = Convert.ToInt32(bin2, 2);
        int int3 = int1 + int2;
        string answer = Convert.ToString(int3, 2);
        return answer;
    }

    /// <summary>
    /// 배열 만들기 4
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution1118(int[] arr)
    {
        int i = 0;
        var stk = new Stack<int>();
        while(i < arr.Length)
        {
            if(stk.Count == 0)
            {
                stk.Push(arr[i]);
                i++;
            }
            else
            {
                if(stk.Peek() < arr[i])
                {
                    stk.Push(arr[i]);
                    i++;
                }
                else
                {
                    stk.Pop();
                }
            }
        }
        int[] answer = new int[stk.Count];
        for(i = stk.Count - 1; i >= 0; i--)
        {
            answer[i] = stk.Pop();
        }
        return answer;
    }

    /// <summary>
    /// 문자 개수 세기
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int[] Solution11172(string my_string)
    {
        int[] answer = new int[52];
        for(int i = 0; i < my_string.Length; i++)
        {
            if(my_string[i] >= 'A' && my_string[i] <= 'Z')
            {
                answer[(int)my_string[i] - 'A'] += 1;
            }
            else if(my_string[i] >= 'a' && my_string[i] <= 'z')
            {
                answer[(int)my_string[i] - 'a' + 26] += 1;
            }
        }
        return answer;
    }

    /// <summary>
    /// 조건 문자열
    /// </summary>
    /// <param name="ineq"></param>
    /// <param name="eq"></param>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int Solution1117(string ineq, string eq, int n, int m)
    {
        int answer = 0;
        if(ineq.Equals(">"))
        {
            if(eq.Equals("="))
            {
                answer = n >= m ? 1 : 0;
            }
            else
            {
                answer = n > m ? 1 : 0;
            }
        }
        else
        {
            if(eq.Equals("="))
            {
                answer = n <= m ? 1 : 0;
            }
            else
            {
                answer = n < m ? 1 : 0;
            }
        }
        return answer;
    }

    /// <summary>
    /// 왼쪽 오른쪽
    /// </summary>
    /// <param name="str_list"></param>
    /// <returns></returns>
    public string[] Solution11142(string[] str_list)
    {
        string[]  strEmpty = new string[]{};
        var listLeft = new List<string>();
        var listRight = new List<string>();
        for(int i = 0; i < str_list.Length; i++)
        {
            if(str_list[i].Equals("l"))
            {
                return listLeft.ToArray();
            }
            else if(str_list[i].Equals("r"))
            {
                for(int j = i + 1 ; j < str_list.Length; j++)
                {
                    listRight.Add(str_list[j]);
                }
                return listRight.ToArray();
            }
            else
            {
                listLeft.Add(str_list[i]);
            }
        }
        return strEmpty;
    }

    /// <summary>
    /// 소인수분해
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution1114(int n)
    {
        var hs = new HashSet<int>();
        for(int i = 2; i <= n; i++)
        {
            while(n % i == 0)
            {
                n = n / i;
                hs.Add(i);
            }
        }
        return hs.ToArray();
    }

    /// <summary>
    /// 배열 만들기 6
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution11132(int[] arr)
    {
        var list = new List<int>();
        int i = 0;
        while(i < arr.Length)
        {
            if(list.Count == 0)
            {
                list.Add(arr[i]);
                i++;
            }
            else
            {
                if(list[list.Count - 1] == arr[i])
                {
                    list.RemoveAt(list.Count - 1);
                    i++;
                }
                else
                {
                    list.Add(arr[i]);
                    i++;
                }
            }
        }
        return (list.Count == 0) ? new int[1] {-1} : list.ToArray();
    }

    /// <summary>
    /// 잘라서 배열로 저장하기
    /// </summary>
    /// <param name="my_str"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string[] Solution1113(string my_str, int n)
    {
        int len = (my_str.Length - 1) / n + 1;
        string[] answer = new string[len];
        int idx = 0, cnt = 0;
        foreach (var item in my_str)
        {
            answer[idx] += item;
            cnt++;
            if(cnt == n)
            {
                idx++;
                cnt = 0;
            }
        }
        return answer;
    }
    /// <summary>
    /// 컨트롤 제트
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int Solution11122(string s)
    {
        int answer = 0;
        string[] strArry = s.Split(" ");
        for (int i = 0; i < strArry.Length; i++)
        {
            if (strArry[i].Equals("Z"))
            {
                answer -= int.Parse(strArry[i - 1]);
            }
            else
            {
                answer += int.Parse(strArry[i]);
            }
        }
        return answer;
    }

    /// <summary>
    /// 커피 심부름
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public int Solution1112(string[] order)
    {
        int answer = 0;
        string americano = "americano";
        string cafelatte = "cafelatte";
        string anything = "anything";
        foreach (var item in order)
        {
            if (item.Contains(americano) || item.Equals(anything))
            {
                answer += 4500;
            }
            else if (item.Contains(cafelatte))
            {
                answer += 5000;
            }
        }

        return answer;
    }

    /// <summary>
    ///  조건에 맞게 수열 변환하기 2
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int Solution11112(int[] arr)
    {
        int answer = 0;
        while (true)
        {
            // 시퀀스 수행 전 배열 저장
            int[] temp = (int[])arr.Clone();

            // 수행
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 50 && arr[i] % 2 == 0)
                    arr[i] /= 2;

                else if (arr[i] < 50 && arr[i] % 2 == 1)
                    arr[i] = (arr[i] * 2) + 1;
            }

            // 전과 후가 같다면 break;
            if (temp.SequenceEqual(arr))
                break;

            // 아니면 반복횟수 증가
            answer++;
        }
        return answer;
    }

    /// <summary>
    /// 특수문자 출력하기
    /// </summary>
    public void Solution1111()
    {
        Console.Write(@"!@#$%^&*(\'");
        Console.Write("\"");
        Console.Write("<>?:;");
    }
    /// <summary>
    /// QR코드
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Solution11102(int q, int r, string code)
    {
        var sb = new StringBuilder();
        /*
        for(int i = 0; i < code.Length; i++)
        {
            if(i % q == r)
            {
                sb.Append(code[i]);
            }
        }
        */
        for (int i = r; i < code.Length; i += q)
        {
            sb.Append(code[i]);
        }
        return sb.ToString();
    }
    /// <summary>
    /// 수열과 쿼리 4
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public int[] Solution1110(int[] arr, int[,] queries)
    {
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            int start = queries[i, 0];
            int end = queries[i, 1];
            int k = queries[i, 2];
            for (int j = start; j <= end; j++)
            {
                if (j % k == 0)
                {
                    arr[j]++;
                }
            }
        }
        return arr;
    }

    /// <summary>
    /// 7의 개수
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int Solution11073(int[] array)
    {
        int answer = 0;
        int num = 0;
        
        for(int i = 0; i < array.Length; i++)
        {
            num = array[i];
            while(num > 0)
            {
                if(num % 10 == 7)
                {
                    answer++;
                }
                num /= 10;
            }
        }
        return answer;
    }

    /// <summary>
    /// 리스트 자르기
    /// </summary>
    /// <param name="n"></param>
    /// <param name="slicer"></param>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution11072(int n, int[] slicer, int[] num_list)
    {
        var list = new List<int>();
        int a = slicer[0];
        int b = slicer[1];
        int c = slicer[2];
        switch (n)
        {
            case 1:
                for (int i = 0; i <= b; i++)
                {
                    list.Add(num_list[i]);
                }
                break;
            case 2:
                for (int i = a; i < num_list.Length; i++)
                {
                    list.Add(num_list[i]);
                }
                break;
            case 3:
                for (int i = a; i <= b; i++)
                {
                    list.Add(num_list[i]);
                }
                break;
            // case 4: 도 가능할 듯.
            default:
                for (int i = a; i <= b; i += c)
                {
                    list.Add(num_list[i]);
                }
                break;
        }

        return list.ToArray();
    }
    
    /// <summary>
    /// 팩토리얼
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution1107(int n)
    {
        int answer = 1, factorial = 1;
        while (factorial <= n)
        {
            answer++;
            factorial *= answer;
        }
        return answer - 1;
    }
    /// <summary>
    /// 가까운 수
    /// </summary>
    /// <param name="array"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution1106(int[] array, int n)
    {
        int answer = array[0];
        int minDiff = Math.Abs(array[0] - n);

        foreach (int num in array)
        {
            int diff = Math.Abs(num - n);
            if (diff < minDiff || (diff == minDiff && num < answer))
            {
                minDiff = diff;
                answer = num;
            }
        }
        return answer;
    }
    /// <summary>
    /// 진료 순서 정하기
    /// </summary>
    /// <param name="emergency"></param>
    /// <returns></returns>
    public int[] Solution1106(int[] emergency)
    {
        int[] answer = new int[emergency.Length];
        /*
        for (int i = 0; i < emergency.Length; i++)
        {
            for (int j = 0; j < emergency.Length; j++)
            {
                if (emergency[i] <= emergency[j])
                {
                    answer[i]++;
                }
            }
        }
        */
        var list = new List<int>(emergency);
        list.Sort();
        list.Reverse();
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = list.IndexOf(emergency[i]) + 1;
        }
        return answer;
    }
    /// <summary>
    /// 간단한 논리 연산
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <param name="x3"></param>
    /// <param name="x4"></param>
    /// <returns></returns>
    public bool Solution11053(bool x1, bool x2, bool x3, bool x4)
    {
        /*
        bool answer = true;
        int i1 = (x1 == true) ? 1 : 0;
        int i2 = (x2 == true) ? 1 : 0;
        int i3 = (x3 == true) ? 1 : 0;
        int i4 = (x4 == true) ? 1 : 0;
        int sum = (i1 + i2) * (i3 + i4);
        answer = (sum == 0) ? false : true;
        */
        bool answer = (x1 | x2) & (x3 | x4);
        return answer;
    }

    /// <summary>
    /// 문자열 반복해서 출력하기
    /// </summary>
    public void Solution1105()
    {
        string[] input;
        Console.Clear();
        input = Console.ReadLine().Split();

        string s1 = input[0];
        int a = int.Parse(input[1]);
        for(int i = 0; i < a; i++)
        {
            Console.Write(s1);
        }
    }
    /// <summary>
    /// 숨어있는 숫자의 덧셈(2)
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution11032(string my_string)
    {
        string str = my_string.ToLower();
        int answer = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 'a' && str[i] <= 'z')
            {
                str = str.Replace(str[i], ' ');
            }
        }

        string[] arr = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < arr.Length; i++)
        {
            answer += int.Parse(arr[i]);
        }
        return answer;
    }

    /// <summary>
    /// 한 번만 등장한 문자
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string Solution1103(string s)
    {
        string answer = string.Empty;
        /*
        // Dictionary 사용
        var dic = new Dictionary<char, int>();
        foreach (var item in s)
        {
            if (dic.TryGetValue(item, out int val))
            {
                dic[item]++;
            }
            else
            {
                dic.Add(item, 1);
            }
        }
        var list = new List<char>();
        foreach (var item in dic)
        {
            if (item.Value == 1)
            {
                list.Add(item.Key);
            }
        }
        list.Sort();
        foreach (var item in list)
        {
            answer += item;
        }
        */
        for (char c = 'a'; c <= 'z'; c++)
        {
            if (s.Split(c).Length == 2)
            {
                answer += c;
            }
        }
        return answer;
        
    }
    #endregion

    #region 10월 문제풀이
    /// <summary>
    /// 세 개의 구분자
    /// </summary>
    /// <param name="myStr"></param>
    /// <returns></returns>
    public string[] Solution10312(string myStr)
    {
        var list = new List<string>();
        char[] splitArr = { 'a', 'b', 'c' };
        string[] strArr = myStr.Split(splitArr);
        foreach (var item in strArr)
        {
            if (item.Length > 0)
            {
                list.Add(item);
            }
        }
        if (list.Count == 0)
        {
            list.Add("EMPTY");
        }
        return list.ToArray();
    }

    /// <summary>
    /// 문자열 묶기
    /// </summary>
    /// <param name="strArr"></param>
    /// <returns></returns>
    public int Solution1031(string[] strArr)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int answer = 0;
        foreach (var item in strArr)
        {
            int len = item.Length;
            if (dic.ContainsKey(len))
            {
                dic[len]++;
            }
            else
            {
                dic[len] = 1;
            }
        }
        /*
        foreach (var item in dic)
        {
            if (item.Value > answer)
            {
                answer = item.Value;
            }
        }
        */
        foreach (var item in dic.Values)
        {
            if (answer < item)
            {
                answer = item;
            }
        }
        return answer;
    }

    /// <summary>
    /// k의 개수
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int Solution10302(int i, int j, int k)
    {
        int answer = 0;
        for(int idx = i; idx <= j; idx++)
        {
            string strIdx = idx.ToString();
            foreach(var item in strIdx)
            {
                int val = item - '0';
                if(k == val)
                {
                    answer++;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 2차원으로 만들기
    /// </summary>
    /// <param name="num_list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[,] Solution1030(int[] num_list, int n)
    {
        int len = num_list.Length / n;
        int[,] answer = new int[len, n];
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < n; j++)
            {
                answer[i, j] = num_list[i * n + j];
            }
        }
        // 콘솔에 답을 찍자.
        int di1 = answer.GetLength(0);
        int di2 = answer.GetLength(1);
        for (int i = 0; i < di1; i++)
        {
            Console.Write("[");
            for (int j = 0; j < di2; j++)
            {
                Console.Write($"{answer[i, j]}");
                if (j != di2 - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
            if(i != di1-1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
        return answer;
    }
    
    /// <summary>
    /// 모스부호
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    public string Solution10292(string letter)
    {
        string answer = "";
        string[] mos = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
        // Split()은 문자열을 잘라주고 현재 공백을 기준으로 자름
        foreach(string a in letter.Split(" "))
        {
            // IndexOf()는 동일한 문자열이 존재할 경우 문자열의 위치를 반환한다. 문자열의 위치에 97을 더해 Covert.ToChar()로 변환하면 그에 맞는 문자로 변환된다.
            answer += Convert.ToChar(Array.IndexOf(mos, a) + 97);
        }
        return answer;

    }

    /// <summary>
    /// A로 B 만들기
    /// </summary>
    /// <param name="before"></param>
    /// <param name="after"></param>
    /// <returns></returns>
    public int Solution1029(string before, string after)
    {
        /*
        int answer = 0;
        char[] bChars = before.ToCharArray();
        char[] aChars = after.ToCharArray();
        Array.Sort(bChars);
        Array.Sort(aChars);
        bool result = bChars.SequenceEqual(aChars);
        if (result == true)
        {
            answer = 1;
        }
        return answer;
        */
        char[] arr = before.ToCharArray();
        char[] arr2 = after.ToCharArray();

        int answer = 1;

        Array.Sort(arr);
        Array.Sort(arr2);

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != arr2[i])
            {
                answer = 0;
                break;
            }
        }
        return answer;
    }

    /// <summary>
    /// 배열의 길이를 2의 거듭제곱으로 만들기
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution10282(int[] arr)
    {
        int len = arr.Length;
        int twice = 1;
        while (twice < len)
        {
            twice *= 2;
        }
        Array.Resize(ref arr, twice);
        return arr;
    }

    /// <summary>
    /// 수열과 구간 쿼리 3
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public int[] Solution1028(int[] arr, int[,] queries)
    {
        // int temp = 0;
        // for (int i = 0; i < queries.GetLength(0); i++)
        // {
        //     temp = arr[queries[i, 0]];
        //     arr[queries[i, 0]] = arr[queries[i, 1]];
        //     arr[queries[i, 1]] = temp;
        // }
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            (arr[queries[i, 0]], arr[queries[i, 1]]) = (arr[queries[i, 1]], arr[queries[i, 0]]);
        }
        return arr;
    }

    /// <summary>
    /// 문자열이 몇 번 등장하는지 세기
    /// </summary>
    /// <param name="myString"></param>
    /// <param name="pat"></param>
    /// <returns></returns>
    public int Solution10272(string myString, string pat)
    {
        int answer = 0;
        for (int i = 0; i < myString.Length; i++)
        {
            if (myString.Substring(i).StartsWith(pat))
            {
                answer++;
            }
        }
        return answer;
    }
    
    /// <summary>
    /// 특정 문자열로 끝나는 가장 긴 부분 문자열 찾기
    /// </summary>
    /// <param name="myString"></param>
    /// <param name="pat"></param>
    /// <returns></returns>
    public string Solution1027(string myString, string pat)
    {
        // int idx = myString.LastIndexOf(pat);
        int idx = -1;
        int len = myString.Length - pat.Length;
        for(int i = 0; i <= len; i++)
        {
            string str = myString.Remove(0, i);
            int last = str.IndexOf(pat);
            if(last > -1)
            {
                idx = i;
            }
        }
        string answer = myString.Substring(0, idx + pat.Length);
        return answer;
    }
    
    /// <summary>
    /// 문자열 뒤집기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="s"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public string Solution10242(string my_string, int s, int e)
    {
        char[] chr = my_string.ToCharArray();
        Array.Reverse(chr, s, e - s + 1);
        return new string(chr);
    }

    /// <summary>
    /// 1로 만들기
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution1024(int[] num_list)
    {
        int answer = 0;
        foreach (var num in num_list)
        {
            int item = num;
            while (item > 1)
            {
                if (item % 2 == 0)
                {
                    item /= 2;
                }
                else
                {
                    item = (item - 1) / 2;
                }
                answer++;
            }
            
        }
        return answer;
    }
    public int[] Solution10232(string[] intStrs, int k, int s, int l)
    {
        var list = new List<int>();
        for (int i = 0, j = 0; i < intStrs.Length; i++)
        {
            j = int.Parse(intStrs[i].Substring(s, l));
            if (j > k)
            {
                list.Add(j);
            }
        }
        return list.ToArray();
    }
    /// <summary>
    /// 글자 지우기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="indices"></param>
    /// <returns></returns>
    public string Solution1023(string my_string, int[] indices)
    {
        /*
        var sb = new StringBuilder();
        var list = new List<int>(indices);
        for (int i = 0; i < my_string.Length; i++)
        {
            if(!list.Contains(i))
            {
                sb.Append(my_string[i]);
            }
        }
        return sb.ToString();
        */
        char[] chars = my_string.ToCharArray();
        for (int i = 0; i < indices.Length; i++)
        {
            chars[indices[i]] = ' ';
        }
        string answer = new string(chars);
        answer = answer.Replace(" ", "");
        return answer;
    }
    
    /// <summary>
    /// 합성수 찾기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution10212(int n)
    {
        if (n < 4)
            return 0;

        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
            isPrime[i] = true;

        
        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                    isPrime[j] = false;
            }
        }

        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i > 1 && !isPrime[i])
                count++;
        }

        return count;
    }
    
    /// <summary>
    /// 중복된 문자 제거
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution1021(string my_string)
    {
        string answer = string.Empty;
        foreach (var item in my_string)
        {
            if (!answer.Contains(item))
            {
                answer += item;
            }
        }
        return answer;

    }
    /// <summary>
    /// 날짜 비교하기
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public int Solution10202(int[] date1, int[] date2)
    {
        const int YEAR = 0;
        const int MONTH = 1;
        const int DAY = 2;
        // 직접 숫자 비교
        /*
        int answer = 0;
        if (date1[YEAR] < date2[YEAR])
        {
            answer = 1;
        }
        else if (date1[YEAR] == date2[YEAR])
        {
            if (date1[MONTH] < date2[MONTH])
            {
                answer = 1;
            }
            else if(date1[MONTH] == date2[MONTH])
            {
                if (date1[DAY] < date2[DAY])
                {
                    answer = 1;
                }
            }
        }
        */
        // DateTime 사용
        /*
        DateTime dt1 = new DateTime(date1[YEAR], date1[MONTH], date1[DAY]);
        DateTime dt2 = new DateTime(date2[YEAR], date2[MONTH], date2[DAY]);
        int answer = dt1 < dt2 ? 1 : 0;
        return answer;
        */

        // 숫자 변환을 이용
        int dt1 = Convert.ToInt32($"{date1[YEAR]}{date1[MONTH]}{date1[DAY]}");
        int dt2 = Convert.ToInt32($"{date2[YEAR]}{date2[MONTH]}{date2[DAY]}");
        int answer = dt1 < dt2 ? 1 : 0;
        return answer;
    }

    /// <summary>
    /// 등차수열의 특정한 항만 더하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="d"></param>
    /// <param name="included"></param>
    /// <returns></returns>
    public int Solution1020(int a, int d, bool[] included)
    {
        int answer = 0;
        int len = included.Length;
        for(int i = 0; i < len; i++)
        {
            if(included[i])
            {
                answer += i * d + a;
            }
        }
        return answer;
    }

    /// <summary>
    /// 문자열 섞기
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    public string Solution10172(string str1, string str2)
    {
        var sb = new StringBuilder();
        for(int i = 0; i < str1.Length; i++)
        {
            sb.Append(str1[i]);
            sb.Append(str2[i]);
        }
        return sb.ToString();
    }
    
    /// <summary>
    /// 이차원 배열 대각선 순회하기
    /// </summary>
    /// <param name="board"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int Solution1017(int[,] board, int k)
    {
        int answer = 0;
        for(int i = 0; i < board.GetLength(0); i++)
        {
            for(int j = 0; j < board.GetLength(1); j++)
            {
                if(i + j <= k)
                {
                    answer += board[i, j];
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 문자열 잘라서 정렬하기
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public string[] Solution10162(string myString)
    {
        string[] strArr = myString.Split('x');
        var list = new List<string>();
        foreach (var item in strArr)
        {
            if (item.Length > 0)
            {
                list.Add(item);
            }
        }
        list.Sort();
        return list.ToArray();
    }
    
    /// <summary>
    /// 세로 읽기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="m"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public string Solution1016(string my_string, int m, int c)
    {
        var sb = new StringBuilder();
        for(int i = c - 1; i < my_string.Length; i += m)
        {
            sb.Append(my_string[i]);   
        }
        return sb.ToString();
    }

    /// <summary>
    /// 369게임
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public int Solution10152(int order)
    {
        int answer = 0;
        string strOrder = order.ToString();
        foreach (var item in strOrder)
        {
            switch (item)
            {
                case '3':
                    answer++;
                    break;
                case '6':
                    answer++;
                    break;
                case '9':
                    answer++;
                    break;
            }
        }
        return answer;
    }
    /// <summary>
    /// 배열 회전시키기
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public int[] Solution1015(int[] numbers, string direction)
    {
        int len = numbers.Length;
        int[] answer = new int[len];
        if (direction.Equals("right"))
        {
            answer[0] = numbers[len - 1];
            for (int i = 1; i < len; i++)
            {
                answer[i] = numbers[i - 1];
            }
        }
        else
        {
            for (int i = 0; i < len - 1; i++)
            {
                answer[i] = numbers[i + 1];
            }
            answer[len - 1] = numbers[0];
        }
        return answer;
    }
    /// <summary>
    /// 피자 나눠먹기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution10142(int n)
    {
        int answer = 0;
        /*
        do
        {
            answer++;
        } while (answer * 6 % n != 0);
        */
        answer = Util.LCM(6, n) / 6;
        return answer;
    }
    /// <summary>
    /// 외계 행성의 나이
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    public string Solution1014(int age)
    {
        string answer = string.Empty;
        string strAge = age.ToString();
        while (age > 0)
        {
            int val = age % 10;
            char chr = Convert.ToChar('a' + val);
            answer = chr + answer;
            age /= 10;
        }
        return answer;
    }

    /// <summary>
    /// 5명씩
    /// </summary>
    /// <param name="names"></param>
    /// <returns></returns>
    public string[] Solution10132(string[] names)
    {
        int len = names.Length % 5 != 0 ? names.Length / 5 + 1 : names.Length / 5;
        string[] answer = new string[len];
        for(int i = 0, j = 0; i < names.Length; i += 5, j++)
        {
            answer[j] = names[i];
        }
        return answer;
    }

    /// <summary>
    /// A 강조하기
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public string Solution1013(string myString)
    {
        // var sb = new StringBuilder();
        // foreach(var item in myString)
        // {
        //     if (item.Equals('a'))
        //     {
        //         sb.Append(item.ToString().ToUpper());
        //     }
        //     else if(item.Equals('A'))
        //     {
        //         sb.Append(item.ToString());
        //     }
        //     else
        //     {
        //         sb.Append(item.ToString().ToLower());
        //     }
        // }
        // return sb.ToString();
        return myString.ToLower().Replace('a', 'A');
    }

    /// <summary>
    /// 9로 나눈 나머지
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public int Solution10102(string number)
    {
        int answer = 0;
        foreach(var item in number)
        {
            answer += item - '0';
        }
        return answer % 9;
    }

    /// <summary>
    /// n개 간격의 원소들
    /// </summary>
    /// <param name="num_list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution1010(int[] num_list, int n)
    {
        // List 사용했을 때
        /*
        var list = new List<int>();
        for (int i = 0; i < num_list.Length; i += n)
        {
            list.Add(num_list[i]);
        }
        return list.ToArray();
        */

        int len = num_list.Length % n == 0 ? (num_list.Length / n) : (num_list.Length / n + 1);
        int[] answer = new int[len];
        for (int i = 0, j = 0; i < num_list.Length; i += n, j++)
        {
            answer[j] = num_list[i];
        }
        return answer;
    }
    
    /// <summary>
    /// 할 일 목록
    /// </summary>
    /// <param name="todo_list"></param>
    /// <param name="finished"></param>
    /// <returns></returns>
    public string[] Solution10022(string[] todo_list, bool[] finished)
    {
        // var list = new List<string>();
        // for (int i = 0; i < finished.Length; i++)
        // {
        //     if (finished[i] == false)
        //     {
        //         list.Add(todo_list[i]);
        //     }
        // }
        // return list.ToArray();
        int len = 0;
        foreach (var item in finished)
        {
            if (item == false)
            {
                len++;
            }
        }
        string[] answer = new string[len];
        for (int i = 0, j = 0; i < finished.Length; i++)
        {
            if (finished[i] == false)
            {
                answer[j] = todo_list[i];
                j++;
            }
        }
        return answer;
    }

    /// <summary>
    /// 조건에 맞게 수열 변환하기 1
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution1002(int[] arr)
    {
        int[] answer = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            bool isEven = arr[i] % 2 == 0;
            if (arr[i] < 50 && !isEven)
            {
                answer[i] = arr[i] * 2;
            }
            else if (arr[i] >= 50 && isEven)
            {
                answer[i] = arr[i] / 2;
            }
            else
            {
                answer[i] = arr[i];
            }
        }
        return answer;
    }

    /// <summary>
    /// 배열 만들기 3
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int[] Solution10012(int[] arr, int[,] intervals)
    {
        int len1 = intervals[0, 1] - intervals[0, 0] + 1;
        int len2 = intervals[1, 1] - intervals[1, 0] + 1;
        int len = len1 + len2;
        int[] answer = new int[len];
        Array.Copy(arr, intervals[0, 0], answer, 0, len1);
        Array.Copy(arr, intervals[1, 0], answer, len1, len2);
        return answer;
    }

    /// <summary>
    /// 길이에 따른 연산
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution1001(int[] num_list)
    {
        int answer = 0;
        int len = num_list.Length;
        if (len > 10)
        {
            foreach (var item in num_list)
            {
                answer += item;
            }
        }
        else
        {
            answer = 1;
            foreach (var item in num_list)
            {
                answer *= item;
            }
        }
        return answer;
    }
    #endregion

    #region 9월 문제풀이
    
    /// <summary>
    /// 원소들의 곱과 합
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution09292(int[] num_list)
    {
        int numTimes = 1;
        int numSum = 0;
        foreach (var item in num_list)
        {
            numTimes *= item;
            numSum += item;
        }
        numSum = numSum * numSum;

        return numTimes < numSum ? 1 : 0;
    }

    /// <summary>
    /// 접미사인지 확인하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="is_suffix"></param>
    /// <returns></returns>
    public int Solution0929(string my_string, string is_suffix)
    {
        int msl = my_string.Length;
        int isl = is_suffix.Length;
        if (isl > msl) return 0;
        else
        {
            // if (my_string.Substring(msl - isl, isl) == is_suffix)
            // if(my_string.Substring(msl - isl, isl).Equals(is_suffix))
            // {
            //     return 1;
            // }
            // else
            // {
            //     return 0;
            // }
            return my_string.Substring(msl - isl, isl).Equals(is_suffix) ? 1 : 0;
        }
    }

    /// <summary>
    /// 홀짝에 따라 다른 값 반환하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution09262(int n)
    {
        int answer = 0;
        if (n % 2 == 0)
        {
            for (int i = 2; i <= n; i += 2)
            {
                answer += i * i;
            }
        }
        else
        {
            for (int i = 1; i <= n; i += 2)
            {
                answer += i;
            }
        }
        return answer;
    }

    /// <summary>
    /// 두 수의 연산값 비교하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution0926(int a, int b)
    {
        //string abStr = a.ToString() + b.ToString();
        //string abStr = "" + a + b;
        string abStr = $"{a}{b}";
        int ab = int.Parse(abStr);
        int twoab = 2 * a * b;
        //int answer = ab > twoab ? ab : twoab;
        int answer = Math.Max(ab, twoab);
        return answer;
    }
    /// <summary>
    /// 카운트 업
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public int[] Solution09252(int start, int end)
    {
        int len = end - start + 1;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[i] = start + i;
        }
        return answer;
    }
    /// <summary>
    /// 대문자로 바꾸기
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public string Solution0925(string myString) => myString.ToUpper();

    /// <summary>
    /// 소문자로 바꾸기
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public string Solution09242(string myString) => myString.ToLower();
    // {
    //     return myString.ToLower();
    // }

    /// <summary>
    /// 간단한 식 계산하기
    /// </summary>
    /// <param name="binomial"></param>
    /// <returns></returns>
    public int Solution0924(string binomial)
    {
        int answer = 0;
        string[] str = binomial.Split(" ");
        int a = int.Parse(str[0]);
        int b = int.Parse(str[2]);
        string c = str[1];
        for (int i = 0; i < str.Length; i++)
        {
            // switch (str[1])
            // {
            //     case "+":
            //         answer = a + b;
            //         break;
            //     case "-":
            //         answer = a - b;
            //         break;
            //     case "*":
            //         answer = a * b;
            //         break;
            //     default:
            //         break;
            // }
            // 최신 switch로 변경
            answer = str[1] switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
            };
        }
        return answer;
    }

    /// <summary>
    /// 배열에서 문자열 대소문자 변환하기
    /// </summary>
    /// <param name="strArr"></param>
    /// <returns></returns>
    public string[] Solution09232(string[] strArr)
    {
        /*
        string[] answer = new string[strArr.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = (i % 2 == 0) ? strArr[i].ToLower() : strArr[i].ToUpper();
        }
        return answer;
        */
        var list = new List<string>();
        bool isEven = true;
        foreach (var item in strArr)
        {
            list.Add(isEven ? item.ToLower() : item.ToUpper());
            isEven = !isEven;
        }
        return list.ToArray();
    }

    /// <summary>
    /// rny_string
    /// </summary>
    /// <param name="rny_string"></param>
    /// <returns></returns>
    public string Solution0923(string rny_string)
    {
        // 아래 주석은 MyExtension에 있는 확장 메서드 사용한 것 (문제풀이에 사용 불가)
        // string answer = rny_string.Replace('m', "rn");
        string answer = rny_string.Replace("m", "rn");
        return answer;
    }

    /// <summary>
    /// 공백으로 구분하기 2
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string[] Solution09222(string my_string)
    {
        /*
        string[] strArr = my_string.Split();
        
        var list = new List<string>();
        foreach (var item in strArr)
        {
            if (!item.Equals(string.Empty))
            {
                list.Add(item);
            }
        }
        
        var list = new List<string>(strArr);
        foreach (var item in strArr)
        {
            list.Remove("");
        }
        return list.ToArray();
        */
        return my_string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
    /// <summary>
    /// 공백으로 구분하기 1
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string[] Solution0922(string my_string)
    {
        string[] answer = my_string.Split(' ');
        return answer;
    }

    /// <summary>
    /// 홀수 vs 짝수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution09192(int[] num_list)
    {
        int oddSum = 0;
        int evenSum = 0;
        /*
        for (int i = 0; i < num_list.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddSum += num_list[i];
            }
            else
            {
                evenSum += num_list[i];
            }
        }
        */
        bool isOdd = true;
        foreach (var item in num_list)
        {
            if (isOdd == true)
            {
                oddSum += item;
            }
            else
            {
                evenSum += item;
            }
            isOdd = !isOdd;
        }
        return Math.Max(evenSum, oddSum);
    }

    /// <summary>
    /// x 사이의 개수
    /// </summary>
    /// <param name="myString"></param>
    /// <returns></returns>
    public int[] Solution0919(string myString)
    {
        string[] strArr = myString.Split('x');
        int[] answer = new int[strArr.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = strArr[i].Length;
        }
        return answer;
        // string[] strArr = myString.Split('x');
        // var list = new List<int>();
        // foreach (var item in strArr)
        // {
        //     list.Add(item.Length);
        // }
        // return list.ToArray();
    }

    /// <summary>
    /// 배열의 원소만큼 추가하기
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution09182(int[] arr)
    {
        var list = new List<int>();
        foreach (var item in arr)
        {
            for (int i = 0; i < item; i++)
            {
                list.Add(item);
            }
        }
        return list.ToArray();
    }
    /// <summary>
    /// ad 제거하기
    /// </summary>
    /// <param name="strArr"></param>
    /// <returns></returns>
    public string[] Solution0918(string[] strArr)
    {
        var list = new List<string>();
        foreach (var item in strArr)
        {
            if (!item.Contains("ad"))
            {
                list.Add(item);
            }
        }
        return list.ToArray();
    }

    /// <summary>
    /// 주사위 게임 1
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
    #endregion 9월 문제풀이

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
    #endregion 8월 문제풀이

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
    #endregion 7월 문제풀이
}