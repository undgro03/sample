using NCMB;
using System.Collections.Generic;
using UnityEngine;

namespace NCMB
{
    public class UserIdManager
    {
        public void GetUserId()
        {
            int userId;
            NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("UserIdManager");
            query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null) {
                if( objList.Count == 0 ) //userIdが1つも登録されていない場合の処理
                {
                    NCMBObject obj = new NCMBObject("UserIdManager");
                    obj["userId"] = 1;
                    obj.SaveAsync();
                    userId = System.Convert.ToInt32(obj["userId"]);
                }
                else //userIdが登録されている場合の処理
                {
                    userId = System.Convert.ToInt32(objList[0]["userId"]) + 1;
                    objList[0]["userId"] = userId;
                    objList[0].SaveAsync();
                }
                PlayerPrefs.SetString("testId", userId.ToString("D8"));
            }
            });
        }
    }
}
