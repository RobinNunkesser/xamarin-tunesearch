using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommonPorts;
using MusicPorts;

namespace TuneSearch.Core
{
    public class SearchTracksService : ISearchTracksService
    {
        private readonly ITunesSearchEngine _searchEngine;

        public SearchTracksService(ITunesSearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public async Task Execute(ISearchTerm commandDto,
            Action<List<ICollectionEntity>> successHandler, Action<Exception> errorHandler)
        {
            var result = await _searchEngine.GetSongs(commandDto.Term);

            var mappedResult = result.Map(tracks =>
            {
                var collectionsList = new List<ICollectionEntity>();
                var collections = tracks.OrderBy(t => t).GroupBy(t => t.ArtistName + " - " + t.CollectionName);
                foreach (var collection in collections)
                {
                    var collectionEntity = new CollectionEntity()
                    {
                        Name = collection.Key
                    };
                    foreach (var track in collection)
                    {
                        collectionEntity.Tracks.Add(track);
                    }
                    collectionsList.Add(collectionEntity);
                }
                return collectionsList;
            });
            
            mappedResult.Match(successHandler, errorHandler);
        }

    }
}