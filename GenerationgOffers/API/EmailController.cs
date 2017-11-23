using GenerationgOffers.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenerationgOffers.API
{
    public class EmailController : ApiController
    {
        private readonly EmailService _emailService;
        public EmailController()
        {
            _emailService = new EmailService();
        }
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync()
        {
            string emailContent;

            using (var contentStream = await this.Request.Content.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    emailContent = sr.ReadToEnd();
                }
            }

            _emailService.ValidateEmail(emailContent);

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }
    }
}
