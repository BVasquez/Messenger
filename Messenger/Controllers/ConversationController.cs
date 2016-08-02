using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class ConversationController : Controller
    {
        MessengerContext db = new MessengerContext();

        public ActionResult Friend(int userFrom, int userTo, string CV)
        {
            PersonalizationViewModels personalizationFrom = db.Personalizations.Find(userFrom);
            PersonalizationViewModels personalizationTo = db.Personalizations.Find(userTo);

            ViewBag.UserPhotoProfileFrom = "/Images/Profile/" + personalizationFrom.PhotoProfile;
            ViewBag.UserPhotoProfileTo = "/Images/Profile/" + personalizationTo.PhotoProfile;
            ViewBag.UserBackgroundTo = "/Images/Background/" + personalizationTo.PhotoBackground;
            ViewBag.UserColorTo = personalizationTo.Color;
            ViewBag.UserTextColor = personalizationTo.TextColor;
            ViewBag.UserStatusMessage = personalizationTo.Status;
            ViewBag.UserConnectionStatus = personalizationTo.ConnectionStatus;

            ViewBag.UserConnectionStateColorTo = Helper.getStatusColor(personalizationTo.ConnectionStatus);
            ViewBag.UserConnectionStateColorFrom = Helper.getStatusColor(personalizationFrom.ConnectionStatus);

            ViewBag.UserToChatName = Helper.getUser(userTo);
            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px" ,"30px" ,"35px"});
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[]{ "normal", "italic" });

            string ConversationConvinated1 = userFrom.ToString() + userTo.ToString();
            string ConversationConvinated2 = userTo.ToString() + userFrom.ToString();
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Friend(ConversationViewModels conver)
        {
            PersonalizationViewModels personalizationFrom = db.Personalizations.Find(int.Parse(Request.QueryString["userFrom"]));
            PersonalizationViewModels personalizationTo = db.Personalizations.Find(int.Parse(Request.QueryString["userTo"]));

            ViewBag.UserPhotoProfileFrom = "/Images/Profile/" + personalizationFrom.PhotoProfile;
            ViewBag.UserPhotoProfileTo = "/Images/Profile/" + personalizationTo.PhotoProfile;
            ViewBag.UserBackgroundTo = "/Images/Background/" + personalizationTo.PhotoBackground;
            ViewBag.UserColorTo = personalizationTo.Color;
            ViewBag.UserTextColor = personalizationTo.TextColor;
            ViewBag.UserStatusMessage = personalizationTo.Status;
            ViewBag.UserConnectionStatus = personalizationTo.ConnectionStatus;

            ViewBag.UserConnectionStateColorTo = Helper.getStatusColor(personalizationTo.ConnectionStatus);
            ViewBag.UserConnectionStateColorFrom = Helper.getStatusColor(personalizationFrom.ConnectionStatus);

            ViewBag.UserToChatName = Helper.getUser(Convert.ToInt32(Request.QueryString["userTo"]));
            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px", "30px", "35px" });
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[] { "normal", "italic" });

            if (ModelState.IsValid)
            {
                db.Conversations.Add(conver);
                db.SaveChanges();
            }
            string ConversationConvinated1 = Request.QueryString["userFrom"] + Request.QueryString["userTo"];
            string ConversationConvinated2 = Request.QueryString["userTo"] + Request.QueryString["userFrom"];
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostingImage(int userFrom, int userTo, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posted"), file.FileName);
                file.SaveAs(path);

                ConversationViewModels conv = new ConversationViewModels()
                {
                    Conversation = userFrom.ToString() + userTo.ToString(),
                    From = userFrom,
                    To = userTo,
                    Time = DateTime.Now,
                    Message = file.FileName,
                    DataType = "image"
                };
                db.Conversations.Add(conv);
                db.SaveChanges();
            }
            return RedirectToAction("Friend", new { userfrom = userFrom, userto = userTo, CV=string.Format("{0}{1}",userFrom,userTo)});
        }



        [HttpPost]
        public ActionResult setPhotoProfile(int userFrom, int userTo, string picChosen, HttpPostedFileBase picUploaded)
        {
            if(ModelState.IsValid)
            {
                PersonalizationViewModels personalization = db.Personalizations.Find(userFrom);
                personalization.PhotoProfile = string.Format("default/{0}.png", picChosen);
                if(picUploaded != null)
                {
                    string ProfilePhotoFormat = picUploaded.FileName.Substring(picUploaded.FileName.Length - 4);
                    picUploaded.SaveAs(Server.MapPath("~/Images/Profile/default/") + string.Format("per_{0}{1}", userFrom, ProfilePhotoFormat));
                    personalization.PhotoProfile = string.Format("per_{0}{1}", userFrom, ProfilePhotoFormat);
                }
                db.Entry(personalization).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Friend", new { userfrom = userFrom, userto = userTo, CV = string.Format("{0}{1}", userFrom, userTo) });
            }

            return View();
        }







        //------------------------------------------------------------------------------------------------------------


        public ActionResult Group(int UserFrom, int GroupId)
        {
            var groupconversation = db.ConversationGroups.Where(x => x.GroupId == GroupId).ToList();
            GroupListViewModels getGroupInfo = db.Groups.Find(GroupId);
            ViewBag.GroupName = getGroupInfo.Name;
            ViewBag.GroupColor = getGroupInfo.Color;
            ViewBag.GroupTextColor = getGroupInfo.TextColor;
            ViewBag.GroupBackground = "/Images/Background/" + getGroupInfo.Background;
            ViewBag.GroupPhoto = "/Images/Profile/" + getGroupInfo.ProfilePhoto;
            ViewBag.GroupMemberCount = db.Members.Where(x => x.GroupId == GroupId).Count();

            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px", "30px", "35px" });
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[] { "normal", "italic" });

            ViewBag.FriendStack = from user in db.Users
                                  join friend in db.Friends on user.UserId equals friend.Friend
                                  where friend.UserId == UserFrom
                                  select user;

            ViewBag.MemberStack =  (from user in db.Users
                                  join member in db.Members on user.UserId equals member.Member
                                  join personalization in db.Personalizations on member.Member equals personalization.User
                                  where member.GroupId == GroupId
                                  select new MemberListDTO(){
                                     Id = user.UserId,
                                     PhotoProfile = "/Images/Profile/"+ personalization.PhotoProfile,
                                     Name = user.FirstName +" "+ user.LastName,
                                     Status = personalization.ConnectionStatus
                                  }).ToList();  

            return View(groupconversation);
        }



        [HttpPost]
        public ActionResult Group(int UserFrom, int GroupId, ConversationGroupViewModels convgroup)
        {

            if (ModelState.IsValid)
            {
                db.ConversationGroups.Add(convgroup);
                db.SaveChanges();
            }


            var groupconversation = db.ConversationGroups.Where(x => x.GroupId == GroupId).ToList();
            GroupListViewModels getGroupInfo = db.Groups.Find(GroupId);
            ViewBag.GroupName = getGroupInfo.Name;
            ViewBag.GroupColor = getGroupInfo.Color;
            ViewBag.GroupTextColor = getGroupInfo.TextColor;
            ViewBag.GroupBackground = "/Images/Background/" + getGroupInfo.Background;
            ViewBag.GroupPhoto = "/Images/Profile/" + getGroupInfo.ProfilePhoto;
            ViewBag.GroupMemberCount = db.Members.Where(x => x.GroupId == GroupId).Count();

            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px", "30px", "35px" });
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[] { "normal", "italic" });

            ViewBag.FriendStack = from user in db.Users
                                  join friend in db.Friends on user.UserId equals friend.Friend
                                  where friend.UserId == UserFrom
                                  select user;

            ViewBag.MemberStack = (from user in db.Users
                                   join member in db.Members on user.UserId equals member.Member
                                   join personalization in db.Personalizations on member.Member equals personalization.User
                                   where member.GroupId == GroupId
                                   select new MemberListDTO()
                                   {
                                       Id = user.UserId,
                                       PhotoProfile = "/Images/Profile/" + personalization.PhotoProfile,
                                       Name = user.FirstName + " " + user.LastName,
                                       Status = personalization.ConnectionStatus
                                   }).ToList();

            return View(groupconversation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupPostingImage(int userFrom, int groupId, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posted"), file.FileName);
                file.SaveAs(path);

                ConversationGroupViewModels conv = new ConversationGroupViewModels()
                {
                    From = userFrom,
                    GroupId = groupId,
                    Time = DateTime.Now,
                    Message = file.FileName,
                    DataType = "image"
                };
                db.ConversationGroups.Add(conv);
                db.SaveChanges();
            }
            return RedirectToAction("Group", new { groupId = groupId, UserFrom = userFrom });
        }


        [HttpPost]
        public ActionResult CreateGroup(string GroupName, int UserFrom)
        {
            if (ModelState.IsValid)
            {
                GroupListViewModels group = new GroupListViewModels();
                group.Name = GroupName;
                group.ProfilePhoto = "defaultProfileGroup.png";
                group.Background = "Comple_default_header.png";
                group.Color = "#48b8ea";
                group.TextColor = "black";
                db.Groups.Add(group);
                db.SaveChanges();

                List<GroupListViewModels> getGroupId = db.Groups.Where(x => x.Name == GroupName).ToList();
                GroupMemberViewModels member = new GroupMemberViewModels() {
                    GroupId = getGroupId[0].GroupListId,
                    Member = UserFrom
                };
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Group", new { groupId = getGroupId[0].GroupListId, UserFrom = UserFrom });
            }
            return View();
        }


        [HttpPost]
        public ActionResult AddUserToGroup(int currUsr, GroupMemberViewModels groupmember)
        {
            if(ModelState.IsValid)
            {
                List<GroupMemberViewModels> member = db.Members.Where(x => x.Member == groupmember.Member && x.GroupId == groupmember.GroupId).ToList();
                if (member.Count == 0)
                {
                    db.Members.Add(groupmember);
                    db.SaveChanges();
                }
               
            }
            return RedirectToAction("Group", new { groupId = groupmember.GroupId, UserFrom = currUsr });
        }


        [HttpPost]
        public ActionResult RemoveUserToGroup(int userFrom, FormCollection val)
        {
            int usertodelete = int.Parse(val["UserToDelete"]);
            int groupid = int.Parse(val["GroupId"]);

            if (ModelState.IsValid)
            {
                List<GroupMemberViewModels> member = db.Members.Where(x => x.Member == usertodelete && x.GroupId == groupid).ToList();
                if (member.Count != 0)
                {
                    db.Members.Remove(member[0]);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Group", new { groupId = groupid, UserFrom = userFrom });
        }





        [HttpPost]
        public ActionResult SetPersonalization(int currentUser, int groupId, FormCollection val, HttpPostedFileBase PerProfilePhoto, HttpPostedFileBase PerBackground)
        {
            if (ModelState.IsValid)
            {
                GroupListViewModels GroupListpersonalization = db.Groups.Find(groupId);

                if (PerProfilePhoto != null)
                {
                    string ProfilePhotoFormat = PerProfilePhoto.FileName.Substring(PerProfilePhoto.FileName.Length - 4);
                    PerProfilePhoto.SaveAs(Server.MapPath("~/Images/Profile/") + string.Format("grpp_{0}{1}", currentUser, ProfilePhotoFormat));
                    GroupListpersonalization.ProfilePhoto= string.Format("grpp_{0}{1}", currentUser, ProfilePhotoFormat);
                }
                if (PerBackground != null)
                {
                    string BackgroundFormat = PerBackground.FileName.Substring(PerBackground.FileName.Length - 4);
                    PerBackground.SaveAs(Server.MapPath("~/Images/Background/") + string.Format("grpb_{0}{1}", currentUser, BackgroundFormat));
                    GroupListpersonalization.Background = string.Format("grpb_{0}{1}", currentUser, BackgroundFormat);
                }

                GroupListpersonalization.Name = val["PerGroupName"];
                GroupListpersonalization.Color = val["PerColor"];
                GroupListpersonalization.TextColor = val["PerColorText"];
                db.Entry(GroupListpersonalization).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Group", "Conversation", new { UserFrom = currentUser, GroupId = groupId });
            }
            return View();
        }


    }
}