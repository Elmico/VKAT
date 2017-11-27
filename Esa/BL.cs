namespace Esa
{
    public class Ammattiala
    {
        //public int id { get; set; }
        public string organisaatio { get; set; }
        public string ammattiala { get; set; }
        public string tyotehtava { get; set; }
        //public string tyoavain { get; set; }
        public string osoite { get; set; }
        public string haku_paattyy_pvm { get; set; }
        public string linkki { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {0}, {0}, {0}, {0}, {0}", organisaatio, ammattiala, tyotehtava, osoite, haku_paattyy_pvm, linkki);
        }
    }       

    public class RootObject
    {
        public string ammattiala { get; set; }
        public string linkki { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", ammattiala);
        }
    }
}