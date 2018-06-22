using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Timing {

    public class TimerHttpJob : IDisposable {
        Timer timer;
        HttpClient client;
        public TimerHttpJob (int period, string url, string path, string targetValue, string userId) {
            Period = period;
            client = new HttpClient ();
            timer = new Timer (async obj => {
                if (await IsMatch (url, path, targetValue))
                    Notify (userId);
            }, null, 0, period * 1000);
        }

        private void Notify (string userId) {
            throw new NotImplementedException ();
        }

        public async Task<bool> IsMatch (string url, string path, string targetValue) {
            var rst = await new HttpClient ().GetStringAsync (url);
            return (string) JToken.Parse (rst).SelectToken (path) == targetValue;
        }

        /// <summary>
        /// 周期
        /// 单位：秒
        /// </summary>
        /// <returns></returns>
        public int Period { get; set; }

        [StringLength (256)]
        public string Url { get; set; }

        [StringLength (128)]
        public string Path { get; set; }

        [StringLength (32)]
        public string TargetValue { get; set; }

        [StringLength (32)]
        public string UserId { get; set; }

        public void Dispose () {
            timer.Dispose ();
            client.Dispose ();
        }
    }
}