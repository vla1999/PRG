// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, Jun 5!");
string[] L = File.ReadAllLines(@"C:\PRG\TTCFG\Portfolio_one_day_5_Jun_24.txt");
Random R= new Random();
List<string> LL = new List<string>();
foreach (string line in L)
{
    string[] s = line.Replace("\t", ";").Split(';');
    if (s.Length > 0)
    {
        if (s[0].StartsWith("Stra")) continue;
        if (s.Length < 4) continue;

        string tag = s[0].Replace("\"","");
        if (s[1] == "") continue;
        if (s[5] == "") continue;
        string ticker = s[3];
        int mult = int.Parse(s[1]);
        if (ticker == "") continue;
        if (ticker == "NQ" && mult == 2)
            ticker = "MNQ Jun24";
        else ticker = ticker + " Jun24";
        int num = int.Parse(s[2]);
        double price= double.Parse(s[5]);
        string formattedPrice = string.Format("{0:0.00000000}", price);
        int a= int.Parse(s[6]);
        string bs = a > 0 ? "B" : "S";
        a = Math.Abs(a) * num;
        DateTime T = DateTime.ParseExact(s[4], "M/d/yyyy H:mm",null);
        T = T.AddHours(4);
        int sec = R.Next() % 60;
        int ms = R.Next() % 1000;
        T =T.AddSeconds(sec).AddMilliseconds(ms);
        string date = T.Date.ToString("yyyy-MM-dd");
        string time = T.TimeOfDay.ToString("hh\\:mm\\:ss\\.fff");
        Guid uuid = Guid.NewGuid();
        string uuid_str = uuid.ToString();

        string tt = $" {date}, {time}, CME, {ticker}, {bs}, 28, {a}, {formattedPrice}, F, Direct, LBME2144, {s[0]},,,, Finke, Finke, {uuid_str},,";
        LL.Add(tt);
    }

}
File.WriteAllLines(@"C:\PRG\TTCFG\tt_Portfolio_one_day_5_Jun_24.txt", LL);


