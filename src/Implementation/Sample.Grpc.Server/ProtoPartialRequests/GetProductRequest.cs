using System;

namespace Sample.Grpc.Server
{
    public sealed partial class GetProductRequest
    {
        internal Guid _ProductId
        {
            get
            {
                if (Guid.TryParse(productId_, out Guid id))
                    return id;

                return Guid.Empty;
            }
            set { productId_ = value.ToString(); }
        }
    }
}
