// For more information please refer to https://github.com/checkout/checkout-sdk-net
using Checkout.Disputes.Four;

//API keys
Four.ICheckoutApi api = CheckoutSdk.FourSdk().StaticKeys()
    .PublicKey("public_key")
    .SecretKey("secret_key")
    .Environment(Environment.Sandbox)
    .HttpClientFactory(new DefaultHttpClientFactory())
    .Build();

//OAuth
Four.ICheckoutApi api = CheckoutSdk.FourSdk().OAuth()
    .ClientCredentials("client_id", "client_secret")
    .Scopes(FourOAuthScope.Disputes)
    .Environment(Environment.Sandbox)
    .FilesEnvironment(Environment.Sandbox)
    .Build();

DisputesQueryFilter request = new DisputesQueryFilter
{
    Limit = 250,
    To = DateTime.Now,
};

try
{
    DisputesQueryResponse response = await api.DisputesClient().Query(request);
}
catch (CheckoutApiException e)
{
    // API error
    string requestId = e.RequestId;
    var statusCode = e.HttpStatusCode;
    IDictionary<string, object> errorDetails = e.ErrorDetails;
}
catch (CheckoutArgumentException e)
{
    // Bad arguments
}
catch (CheckoutAuthorizationException e)
{
    // Invalid authorization
}