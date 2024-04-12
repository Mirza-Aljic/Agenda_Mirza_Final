using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Agenda_Mirzav3.Service.DAO
{
    public class DAO_Google_Calendar
    {
        // Identifiants OAuth 2.0
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Agenda Mirza";

        // Chemin d'accès au fichier client_secret.json
        static string credentialsPath = "client_secret.json";

        public IList<Event> GetEvents()
        {
            UserCredential credential;

            // Charger les informations d'identification depuis le fichier credentials.json
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Créer le service Google Calendar API
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Définir les paramètres de la requête
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            

            // Récupérer les événements
            Events events = request.Execute();
            return events.Items;
        }
    }
}
