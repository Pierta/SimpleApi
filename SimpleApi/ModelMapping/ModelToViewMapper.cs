using SimpleApi.Domain.Model;
using SimpleApi.Model;

namespace SimpleApi.ModelMapping
{
    public static class ModelToViewMapper
    {
        public static NewsItemView ConvertToView(NewsItem newsItem)
        {
            return new NewsItemView
            {
                Id = newsItem.Id,
                Author = newsItem.Author,
                Title = newsItem.Title,
                ShortDescription = newsItem.ShortDescription,
                FullDescription = newsItem.FullDescription,
                Created = newsItem.Created,
                Updated = newsItem.Updated,
                UpdatedBy = newsItem.UpdatedBy
            };
        }

        public static NewsItem ConvertToModel(NewsItemView newsItemView)
        {
            return new NewsItem
            {
                Id = newsItemView.Id,
                Author = newsItemView.Author,
                Title = newsItemView.Title,
                ShortDescription = newsItemView.ShortDescription,
                FullDescription = newsItemView.FullDescription,
                Created = newsItemView.Created,
                Updated = newsItemView.Updated,
                UpdatedBy = newsItemView.UpdatedBy
            };
        }
    }
}