using System;
using System.Collections.Generic;
using ExplicitArchitecture;

namespace TuneSearch.Core.Ports
{
    public interface ISearchTracksService : IService<SearchTracksDTO, List<CollectionEntity>>
    {
    }
}
