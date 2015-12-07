using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace TXRXText
{
    class DrunkenXMLSailor
    {

        private string XML;
        private StringBuilder Output;

        public DrunkenXMLSailor(string XML)
        {
            this.XML = XML;
            this.Output = new StringBuilder();

        }

    
        /// <summary>
        /// SailorNavigate
        /// FIX: Aggiungi argomenti ricerca
        /// </summary>
        /// <returns></returns>
        public string SailorNavigate_GetArtistImageBig()
        {
            if (this.XML == String.Empty)
                return String.Empty;
            
            using(XmlReader Reader = XmlReader.Create( new StringReader( this.XML ) ))
            {
                //FIX, CONTROLLA SE IL NODO ESISTE

                Reader.ReadToFollowing("image");
                Reader.ReadToFollowing("image");
                Reader.ReadToFollowing("image");
                Reader.MoveToContent();
                string imgPath = Reader.ReadString();

                if (imgPath == String.Empty)
                    return String.Empty;

                Output.AppendLine(imgPath);
            }
            
            return Output.ToString();
        }
        


        public bool CanNavigate()
        {
            return this.XML != String.Empty;
        }



    }
}
