namespace AndroidApplication1.Model
{
    using System.Collections.Generic;

    /*
     * 
     *  "entry": [
        {
            "id": "10459655",
            "hash": "ad9d845d326eba333689b6c1d5682752",
            "requestHash": "boresight",
            "profileUrl": "http://gravatar.com/boresight",
            "preferredUsername": "boresight",
            "thumbnailUrl": "http://1.gravatar.com/avatar/ad9d845d326eba333689b6c1d5682752",
            "photos": [
                {
                    "value": "http://1.gravatar.com/avatar/ad9d845d326eba333689b6c1d5682752",
                    "type": "thumbnail"
                },
                {
                    "value": "http://2.gravatar.com/userimage/10459655/978fce22ae88a4074533deb608f6770d"
                }
            ],
            "name": {
                "givenName": "Jose Miguel",
                "formatted": "Torres"
            },
            "displayName": "Jose Miguel Torres",
            "aboutMe": "Mi nombre es Jos� Miguel Torres y soy de Igualada (Barcelona). Soy Ingeniero T�cnico en Inform�tica de Sistemas y tengo m�s de 12 a�os de experiencia a mis espaldas. Llevo escribiendo art�culos sobre tecnolog�as Microsoft desde el a�o 2001 en revistas como SoloProgramadores y especialmente en dotNetMania. Adem�s he publicado dos libros sobre SQL Server Compact 2008 publicado por Krasis Press y he sido galardonado como MVP en la categoria de Device Application Development en los a�os 2008, 2009 y 2010. Soy co-fundador del grupo de usuarios de la Catalunya Central (CatDotNet.org) y he sido speaker tanto en reuniones de grupo usuarios locales como en eventos como Mobiltiy Show o el SolidQ Summit. Coordino los proyectos SyncComm y SQLMetal OSUI hospedados en CodePlex. Me podr�s encontrar a menudo en los foros de desarrollo de MSDN especialmente en los de .NET Compact Framework, SQL Server Compact y Sync Services for ADO.NET en ingl�s y Compact Framework en espa�ol d�nde adem�s soy el Moderador.",
            "currentLocation": "Igualada",
            "urls": [ ]
        }
    ]

     */
    public class Gravatar
    {
        public List<GravEntry> entry { get; set; }
    }

    public class GravEntry
    {
        public string Id { get; set; }

        public string ThumbnailUrl { get; set; }

        //no more fields needed so far
    }
}