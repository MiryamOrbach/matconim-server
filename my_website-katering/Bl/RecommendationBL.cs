using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class RecommendationBL
    {
        public static List<RecommendationDto> GetAllRecommendation()
        {
            List<Recommendation> recommendation = RecommendationDal.GetAllRecommendations();
            List<RecommendationDto> recommendationDto = recommendation.Select(r => new RecommendationDto(r)).OrderByDescending(o => o.dateR).ToList();
            return recommendationDto;
        }
        public static List<RecommendationDto> GetRecommendationByIsDisplay(bool isDisplay)
        {
            List<Recommendation> recommendation = RecommendationDal.GetRecommendationByIsDisplay(isDisplay);
            List<RecommendationDto> recommendationDto = recommendation.Select(r => new RecommendationDto(r)).OrderByDescending(o=>o.dateR).ToList();
            return recommendationDto;
        }
        public static RecommendationDto AddRecommendation(RecommendationDto r)
        {
            Recommendation recommendation = RecommendationDto.Todal(r);
            r.idRecommendations = RecommendationDal.AddRecommendation(recommendation);
            return r;

        }
        public static void UpdateIsDisplay(List<RecommendationDto> r)
        {
            foreach (RecommendationDto item in r)
            {
                Recommendation recommendation = RecommendationDto.Todal(item);
                RecommendationDal.UpdateIsDisplay(recommendation);
            }


        }
    }
}
