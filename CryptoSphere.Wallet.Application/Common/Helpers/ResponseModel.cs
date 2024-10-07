namespace CryptoSphere.Wallet.Application.Common.Helpers
{
    public class ResponseModel
    {
        public bool IsValid { get; set; } = false;
        public string ValidationMessage { get; set; }
        public IEnumerable<string> Errors { get; protected set; } = new List<string>();
        public static ResponseModel Success = new(true);
        public ResponseModel(string error) : this(new[] { error }) { }
        public ResponseModel(params string[] errors) => Errors = errors;
        public ResponseModel(IEnumerable<string> errors) => Errors = errors;
        public ResponseModel(bool isValid) => IsValid = isValid;
    }

    public class ResponseModel<TResult> : ResponseModel where TResult : new()
    {
        public TResult? Result { get; set; }
        public ResponseModel(TResult? result)
        {
            IsValid = true;
            Result = result;
        }
        public ResponseModel(params string[] errors) : base(errors) { }
        public ResponseModel(IEnumerable<string> errors) : base(errors) { }
    }

}
