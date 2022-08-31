namespace WEB.Aula01
{
    public class Services
    {
        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1997, 1, 1);
            int range = (DateTime.Today - start).Days;
            Random gen = new Random();
            return start.AddDays(gen.Next(range));
        }
    }
}
