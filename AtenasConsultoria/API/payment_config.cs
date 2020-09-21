namespace AtenasConsultoria.API
{
    public class payment_config
    {
        public boleto boleto { get; set; }
        public credit_card credit_Card { get; set; }
        public string default_payment_method { get; set; }
    }
}