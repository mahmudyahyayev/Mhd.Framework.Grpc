using Mhd.Framework.Core;

namespace Sample.Grpc.Server
{
    public sealed partial class GetProductValidationRequest : RequestValidate
    {
        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
                ValidateResults.Add(new ErrorResult($"Name cannot be null", nameof(Name)));
        }
    }
}
