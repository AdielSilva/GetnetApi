using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Getnet.Models
{
    public class CardPaymentRequest
    {

        [JsonPropertyName("seller_id")]
        public string SellerId { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("order")]
        public Order Order { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("device")]
        public Device Device { get; set; }

        [JsonPropertyName("shippings")]
        public List<Shipping> Shippings { get; set; }

        [JsonPropertyName("sub_merchant")]
        public SubMerchant SubMerchant { get; set; }

        [JsonPropertyName("credit")]
        public Credit Credit { get; set; }

    }

    public class Order
    {
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("sales_tax")]
        public int SalesTax { get; set; }

        [JsonPropertyName("product_type")]
        public string ProductType { get; set; }
    }

    public class BillingAddress
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
    }

    public class Customer
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("document_type")]
        public string DocumentType { get; set; }

        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("billing_address")]
        public BillingAddress BillingAddress { get; set; }
    }

    public class Device
    {
        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
    }

    public class Shipping
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("shipping_amount")]
        public int ShippingAmount { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class SubMerchant
    {
        [JsonPropertyName("identification_code")]
        public string IdentificationCode { get; set; }

        [JsonPropertyName("document_type")]
        public string DocumentType { get; set; }

        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
    }

    public class Card
    {
        [JsonPropertyName("number_token")]
        public string NumberToken { get; set; }

        [JsonPropertyName("cardholder_name")]
        public string CardholderName { get; set; }

        [JsonPropertyName("security_code")]
        public string SecurityCode { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("expiration_month")]
        public string ExpirationMonth { get; set; }

        [JsonPropertyName("expiration_year")]
        public string ExpirationYear { get; set; }
    }

    public class Credit
    {
        [JsonPropertyName("delayed")]
        public bool Delayed { get; set; }

        [JsonPropertyName("pre_authorization")]
        public bool PreAuthorization { get; set; }

        [JsonPropertyName("save_card_data")]
        public bool SaveCardData { get; set; }

        [JsonPropertyName("transaction_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("number_installments")]
        public int NumberInstallments { get; set; }

        [JsonPropertyName("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonPropertyName("dynamic_mcc")]
        public int DynamicMcc { get; set; }

        [JsonPropertyName("card")]
        public Card Card { get; set; }
    }

}
