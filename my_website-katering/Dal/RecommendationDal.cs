using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class RecommendationDal
    {
        public static List<Recommendation> GetAllRecommendations()
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {

                    List<Recommendation> recommendations = db.Recommendations.Include("Customer").ToList();
                    return recommendations;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static List<Recommendation> GetRecommendationByIsDisplay(bool isDisplay)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    List<Recommendation> recommendations = db.Recommendations.Include("Customer").Where(r=>r.isDisplay==isDisplay).ToList();
                    return recommendations;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static void UpdateIsDisplay(Recommendation model)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    Recommendation recommendation = db.Recommendations.Where(r => r.idRecommendations == model.idRecommendations).FirstOrDefault();
                    recommendation.isDisplay = model.isDisplay;
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e ;
                }

            }

        }

            public static int AddRecommendation(Recommendation model)
            {
                using (myProjectEntities db = new myProjectEntities())
                {
                    try
                    {
                        db.Recommendations.Add(model);
                        db.SaveChanges();
                        return model.idRecommendations;
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                }

            }
    }
}
