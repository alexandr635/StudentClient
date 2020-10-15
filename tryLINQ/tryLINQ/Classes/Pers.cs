namespace tryLINQ.Classes
{
    public class Pers
    {
        public int id { set; get; }
        public string name { set; get; }
        public string last_name { set; get; }
        public string phone { set; get; }
        public string language { set; get; }
        public int age { set; get; }

        public Pers(int id, string name, string last_name, string phone, int age, string language)
        {
            this.id = id;
            this.name = name;
            this.last_name = last_name;
            this.phone = phone;
            this.language = language;
            this.age = age;
        }
        public Pers(){}
    }
}
