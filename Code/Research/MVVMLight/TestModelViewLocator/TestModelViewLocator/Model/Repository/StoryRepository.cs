using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestModelViewLocator.Model.Repository
{
    public interface IStoryRepository
    {
        void GetStories();
    }
    public class StoryRepository : IStoryRepository
    {
        public void GetStories()
        {
            throw new NotImplementedException();
        }
    }
}
