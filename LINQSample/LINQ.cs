namespace LINQSample
{
    /// <summary>
    /// LINQサンプルクラスです。
    /// </summary>
    internal static class LINQ
    {
        /// <summary>
        /// LINQを使わないWhereと同じ動きです。
        /// </summary>
        public static void WhereNotLINQ()
        {
            var foods = new string[]
            {
                "ハンバーグ", "カレー", "トンカツ", "カツレツ", "ミートボール"
            };
            var list = new List<string>();
            foreach (var food in foods)
            {
                if (food.Contains("カツ"))
                {
                    list.Add(food);
                }
            }
            Console.WriteLine("◇◇ifを使った場合");
            list.ForEach(food => Console.Write(food));
            Console.WriteLine();
        }

        /// <summary>
        /// LINQを使ってWhereを実行します。
        /// </summary>
        public static void WhereLINQ()
        {
            var foods = new string[]
            {
                "ハンバーグ", "カレー", "トンカツ", "カツレツ", "ミートボール"
            };
            var list = foods.Where(food => food.Contains("カツ")).ToList();
            Console.WriteLine("◇◇LNQを使った場合");
            list.ForEach(food => Console.Write(food));
            Console.WriteLine();
        }

        /// <summary>
        /// LINQを使わないSelectと同じ動きです。
        /// </summary>
        public static void SelectNotLINQ()
        {
            var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = new List<string>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    list.Add(number.ToString());
                }
            }
            Console.WriteLine("◇◇ifを使った場合");
            list.ForEach(str => Console.Write(str));
            Console.WriteLine();
        }

        /// <summary>
        /// LINQを使ってSelectを実行します。
        /// </summary>
        public static void SelectLINQ()
        {
            var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = numbers.Where(x => x % 2 == 0).Select(x => x.ToString()).ToList();
            Console.WriteLine("◇◇LNQを使った場合");
            list.ForEach(str => Console.Write(str));
            Console.WriteLine();
        }

        /// <summary>
        /// LINQを使ってSelectManyを実行します。
        /// </summary>
        /// <remarks>
        /// TestObjectリストが持つValuesの配列を平坦化してリストとします。
        /// </remarks>
        public static void SelectManyLINQ()
        {
            var list = new List<TestObject>
            {
                new(1, "１さん", "１さんの情報です。", new() { "りんご", "パイナップル" }),
                new(2, "２さん", "２さんの情報です。", new() { "キャベツ", "ピーマン" }),
                new(3, "４さん", "４さんの情報です。", new() { "とんかつ", "親子丼", "唐揚げ" }),
                new(4, "３さん", "３さんの情報です。", new() { "コーラ", "ファンタ", "ジョージア", "アクエリアス" }),
                new(5, "４さん", "４さんの情報です。", new() { "tonnkatu", "oyakodon", "karaage" }),
                new(6, "５さん", "５さんの情報です。", new() { "中華", "和食" }),
                new(7, "１さん", "１さんの情報です。", new() { "apple", "Pineapple" }),
            };
            list.SelectMany(x => x.Values).ToList().ForEach(x => Console.WriteLine(x));
        }

        /// <summary>
        /// OrderBy（昇順）の動きです。
        /// </summary>
        public static void OrderByLINQ()
        {
            var numbers = new int[] { 9, 1, 2, 8, 6, 4, 7, 3, 0, 5 };
            Console.WriteLine("- 昇順");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.Write(x));
            Console.WriteLine();
        }

        /// <summary>
        /// OrderBy（降順）の動きです。
        /// </summary>
        public static void OrderByDescendingLINQ()
        {
            var numbers = new int[] { 9, 1, 2, 8, 6, 4, 7, 3, 0, 5 };
            Console.WriteLine("- 降順");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write(x));
            Console.WriteLine();
        }

        /// <summary>
        /// LINQを使ってGroupByを実行します。
        /// </summary>
        public static void GroupByLINQ()
        {
            var list = new List<TestObject>
            {
                new(1, "１さん", "１さんの情報です。", new() { "りんご", "パイナップル" }),
                new(2, "２さん", "２さんの情報です。", new() { "キャベツ", "ピーマン" }),
                new(3, "４さん", "４さんの情報です。", new() { "とんかつ", "親子丼", "唐揚げ" }),
                new(4, "３さん", "３さんの情報です。", new() { "コーラ", "ファンタ", "ジョージア", "アクエリアス" }),
                new(5, "４さん", "４さんの情報です。", new() { "tonnkatu", "oyakodon", "karaage" }),
                new(6, "５さん", "５さんの情報です。", new() { "中華", "和食" }),
                new(7, "１さん", "１さんの情報です。", new() { "apple", "Pineapple" }),
            };
            // 名前でグルーピング
            list.GroupBy(x => x.Name).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key}の情報");
                x.ToList().ForEach(x => Console.WriteLine(x));
            });
        }

        /// <summary>
        /// 計算LINQで利用する数値配列
        /// </summary>
        private static int[] numbers = new int[] { 100, 200, 300, 400, 500 };

        /// <summary>
        /// LINQを使って平均を求めます。
        /// </summary>
        /// <remarks>
        /// 1500 / 5 = 300
        /// </remarks>
        public static void AverageLINQ() =>
            Console.WriteLine(numbers.Average(x => x));

        /// <summary>
        /// LINQを使って最大値を求めます。
        /// </summary>
        /// <remarks>
        /// 500
        /// </remarks>
        public static void MaxLINQ()
            => Console.WriteLine(numbers.Max(x => x));

        /// <summary>
        /// LINQを使って最小値を求めます。
        /// </summary>
        /// <remarks>
        /// 100
        /// </remarks>
        public static void MinLINQ()
            => Console.WriteLine(numbers.Min(x => x));

        /// <summary>
        /// LINQを使って合計を求めます。
        /// </summary>
        /// <remarks>
        /// 1500
        /// </remarks>
        public static void SumLINQ()
            => Console.WriteLine(numbers.Sum(x => x));

        /// <summary>
        /// テストに利用するクラスです。
        /// </summary>
        private class TestObject
        {

            /// <summary>
            /// ID
            /// </summary>
            public int Id { get; }
            /// <summary>
            /// 名前
            /// </summary>
            public string Name { get; }
            /// <summary>
            /// 説明
            /// </summary>
            public string Description { get; }
            /// <summary>
            /// 複数の値
            /// </summary>
            public List<string> Values { get; }
            /// <summary>
            /// テストオブジェクトを初期化します。
            /// </summary>
            /// <param name="id">ID</param>
            /// <param name="name">名前</param>
            /// <param name="description">概要</param>
            /// <param name="values">値</param>
            public TestObject(int id, string name, string description, List<string> values)
                => (Id, Name, Description, Values) = (id, name, description, values);

            /// <summary>
            /// テストオブジェクトを文字列として返します。
            /// </summary>
            /// <returns></returns>
            public override string ToString()
                => $"ID:{Id} Name:{Name} Description:{Description} Values:{string.Join(",",Values)}";

        }
    }
}
