// This file was modified by Kin Ecosystem (2019)


namespace kin_base.responses.results
{
    /// <summary>
    /// Operation successful.
    /// </summary>
    public class PaymentSuccess : PaymentResult
    {
        public override bool IsSuccess => true;
    }
}