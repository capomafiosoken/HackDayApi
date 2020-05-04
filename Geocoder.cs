using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackDayApi
{
    public static class Geocoder
    {
        private static string _csrfToken = "ecbff93872740c25676837626636232d8dace1d7:1588572568";
        public static async Task<YandexResponse> GeocodeAddress(string address)
        {
            string content;
            var handler = new HttpClientHandler
            {
                UseCookies = false
            };
            var httpClient = new HttpClient(handler);
            while (true)
            {
                using var request = new HttpRequestMessage(new HttpMethod("GET"),
                    $"https://yandex.kz/maps/api/search?add_type=direct&csrfToken={_csrfToken}&lang=ru_KZ&origin=maps-form&text={address}&yandex_gid=162&z=19");
                request.Headers.TryAddWithoutValidation("Cookie",
                    "yandexuid=9741003971588572215; i=PZRX3TjCXAkIvvHChltibCbEKLnVppAcu%2Bpu2yMoI%2BujlWXz6FAVl4N6aR1JXomg5fq2BWId%2BPlVX%2FCru%2FR9Q5gfa5s%3D");
                var response = await httpClient.SendAsync(request);
                content = await response.Content.ReadAsStringAsync();
                var csrfTokenResponse = JsonConvert.DeserializeObject<CsrfTokenResponse>(content);
                if (csrfTokenResponse.CsrfToken != null)
                {
                    _csrfToken = csrfTokenResponse.CsrfToken;
                    continue;
                }
                break;
            }
            
            var yandexResponse = JsonConvert.DeserializeObject<YandexResponse>(content);
            return yandexResponse;
        }
    }
}