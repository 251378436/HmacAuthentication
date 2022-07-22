// See https://aka.ms/new-console-template for more information
using Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hello, World!");

string apiBaseAddress = "https://localhost:7092/";
string keyId = "65d3a4f0-0239-404c-8394-21b94ff50604";
string keySecrect = "WLUEWeL3so2hdHhHM5ZYnvzsOUBzSGH4+T3EgrQ91KI=";

HttpClient client = HttpClientFactory.Create();
var order = new Order
{
    OrderID = 10248,
    CustomerName = "Pranaya Rout",
    CustomerAddress = "Mumbai|Mahatashtra|IN",
    ContactNumber = "1234567890",
    IsShipped = true
};

var requestString = System.Text.Json.JsonSerializer.Serialize(order);
client.BaseAddress = new Uri(apiBaseAddress);
// Signature
string signature;
using (var hmac = new HMACSHA256(Convert.FromBase64String(keySecrect)))
{
    signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(requestString)));
}

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("HMAC-SHA256", $"{keyId};{signature}");

HttpContent content = new StringContent(requestString, Encoding.UTF8, "application/json");

var response = await client.PostAsync($"api/WeatherForecast", content);
var responseString = await response.Content.ReadAsStringAsync();

Console.WriteLine(response.StatusCode);
Console.WriteLine(responseString);