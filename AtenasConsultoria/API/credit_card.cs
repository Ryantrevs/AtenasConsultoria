namespace AtenasConsultoria.API
{
    public class credit_card
    {
        public bool enabled { get; set; }
        public int free_installments { get; set; }
        public double interest_rate { get; set; }
        public int max_installments { get; set; }
    }
}