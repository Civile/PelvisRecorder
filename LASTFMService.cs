using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TXRXText
{
    class LASTFMService
    {


        /// <summary>
        /// LoadArtistPicture
        /// </summary>
        /// <param name="ArtistData"></param>
        /// <param name="WebHook"></param>
        /// <param name="XMLSailor"></param>
        /// <param name="PBOX_Cover"></param>
        public void LoadArtistPicture(string ArtistName, CaptainHook WebHook, DrunkenXMLSailor XMLSailor, PictureBox PBOX_Cover) 
        {
            var myAsinc = new LASTFMService.Delegate_CoverLoad(AsyncCoverLoad);
            myAsinc.BeginInvoke(ArtistName.Trim(), WebHook, XMLSailor, PBOX_Cover, null, null);
        }

        delegate void Delegate_CoverLoad(string ArtistName, CaptainHook WebHook, DrunkenXMLSailor XMLSailor, PictureBox PBOX_Cover);
        public static void AsyncCoverLoad(string ArtistName, CaptainHook WebHook, DrunkenXMLSailor XMLSailor, PictureBox PBOX_Cover)
        {
            /*LASTFM API*/
            string GETReq = @"http://ws.audioscrobbler.com/2.0/?method=artist.getInfo&artist=$artist&api_key=d1146fc51bcc3bec1d3fb356398d7362";

            GETReq = GETReq.Replace("$artist", WebUtility.UrlEncode(ArtistName));
            WebHook.HookRequest(GETReq, "GET");
            XMLSailor = new DrunkenXMLSailor(WebHook.HookResponse());

            /*Load cover image*/
            try
            {
                if (XMLSailor.CanNavigate())
                {
                    string imgUrl = XMLSailor.SailorNavigate_GetArtistImageBig();
                    if (!String.IsNullOrEmpty(imgUrl) && imgUrl != String.Empty)
                    {
                        try
                        {
                            PBOX_Cover.BackgroundImage = null;
                            PBOX_Cover.InitialImage = null;
                            PBOX_Cover.Image = null;
                            
                            PBOX_Cover.Load(imgUrl);
                        }
                        catch (ExternalException e)
                        {
                            return;
                        }

                    }

                    else
                    {
                        PBOX_Cover.Image = Image.FromFile("assets/pelvisLogo110.png");
                    }
                }

            }
            catch (ExternalException e)
            {
                return;
            }

        }
    }
}
