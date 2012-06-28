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
            "aboutMe": "Mi nombre es José Miguel Torres y soy de Igualada (Barcelona). Soy Ingeniero Técnico en Informática de Sistemas y tengo más de 12 años de experiencia a mis espaldas. Llevo escribiendo artículos sobre tecnologías Microsoft desde el año 2001 en revistas como SoloProgramadores y especialmente en dotNetMania. Además he publicado dos libros sobre SQL Server Compact 2008 publicado por Krasis Press y he sido galardonado como MVP en la categoria de Device Application Development en los años 2008, 2009 y 2010. Soy co-fundador del grupo de usuarios de la Catalunya Central (CatDotNet.org) y he sido speaker tanto en reuniones de grupo usuarios locales como en eventos como Mobiltiy Show o el SolidQ Summit. Coordino los proyectos SyncComm y SQLMetal OSUI hospedados en CodePlex. Me podrás encontrar a menudo en los foros de desarrollo de MSDN especialmente en los de .NET Compact Framework, SQL Server Compact y Sync Services for ADO.NET en inglés y Compact Framework en español dónde además soy el Moderador.",
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