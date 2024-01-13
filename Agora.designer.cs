﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agora
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AgoraDB")]
	public partial class AgoraDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCommunity(Community instance);
    partial void UpdateCommunity(Community instance);
    partial void DeleteCommunity(Community instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertCommunitiesUser(CommunitiesUser instance);
    partial void UpdateCommunitiesUser(CommunitiesUser instance);
    partial void DeleteCommunitiesUser(CommunitiesUser instance);
    partial void InsertPost(Post instance);
    partial void UpdatePost(Post instance);
    partial void DeletePost(Post instance);
    #endregion
		
		public AgoraDataContext() : 
				base(global::Agora.Properties.Settings.Default.AgoraDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AgoraDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgoraDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgoraDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgoraDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Community> Communities
		{
			get
			{
				return this.GetTable<Community>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<CommunitiesUser> CommunitiesUsers
		{
			get
			{
				return this.GetTable<CommunitiesUser>();
			}
		}
		
		public System.Data.Linq.Table<Post> Posts
		{
			get
			{
				return this.GetTable<Post>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Communities")]
	public partial class Community : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CommunityID;
		
		private string _CommunityName;
		
		private System.Nullable<int> _CommunityAdmin;
		
		private EntitySet<CommunitiesUser> _CommunitiesUsers;
		
		private EntitySet<Post> _Posts;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCommunityIDChanging(int value);
    partial void OnCommunityIDChanged();
    partial void OnCommunityNameChanging(string value);
    partial void OnCommunityNameChanged();
    partial void OnCommunityAdminChanging(System.Nullable<int> value);
    partial void OnCommunityAdminChanged();
    #endregion
		
		public Community()
		{
			this._CommunitiesUsers = new EntitySet<CommunitiesUser>(new Action<CommunitiesUser>(this.attach_CommunitiesUsers), new Action<CommunitiesUser>(this.detach_CommunitiesUsers));
			this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
			this._User = default(EntityRef<User>);
			OnCreated();
		}

        public Community(string communityName, int? communityAdmin) : this()
        {
            _CommunityName = communityName;
            _CommunityAdmin = communityAdmin;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommunityID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CommunityID
		{
			get
			{
				return this._CommunityID;
			}
			set
			{
				if ((this._CommunityID != value))
				{
					this.OnCommunityIDChanging(value);
					this.SendPropertyChanging();
					this._CommunityID = value;
					this.SendPropertyChanged("CommunityID");
					this.OnCommunityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommunityName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string CommunityName
		{
			get
			{
				return this._CommunityName;
			}
			set
			{
				if ((this._CommunityName != value))
				{
					this.OnCommunityNameChanging(value);
					this.SendPropertyChanging();
					this._CommunityName = value;
					this.SendPropertyChanged("CommunityName");
					this.OnCommunityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommunityAdmin", DbType="Int")]
		public System.Nullable<int> CommunityAdmin
		{
			get
			{
				return this._CommunityAdmin;
			}
			set
			{
				if ((this._CommunityAdmin != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCommunityAdminChanging(value);
					this.SendPropertyChanging();
					this._CommunityAdmin = value;
					this.SendPropertyChanged("CommunityAdmin");
					this.OnCommunityAdminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Community_CommunitiesUser", Storage="_CommunitiesUsers", ThisKey="CommunityID", OtherKey="CommunityID")]
		public EntitySet<CommunitiesUser> CommunitiesUsers
		{
			get
			{
				return this._CommunitiesUsers;
			}
			set
			{
				this._CommunitiesUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Community_Post", Storage="_Posts", ThisKey="CommunityID", OtherKey="CommunityID")]
		public EntitySet<Post> Posts
		{
			get
			{
				return this._Posts;
			}
			set
			{
				this._Posts.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Community", Storage="_User", ThisKey="CommunityAdmin", OtherKey="UserID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Communities.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Communities.Add(this);
						this._CommunityAdmin = value.UserID;
					}
					else
					{
						this._CommunityAdmin = default(Nullable<int>);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CommunitiesUsers(CommunitiesUser entity)
		{
			this.SendPropertyChanging();
			entity.Community = this;
		}
		
		private void detach_CommunitiesUsers(CommunitiesUser entity)
		{
			this.SendPropertyChanging();
			entity.Community = null;
		}
		
		private void attach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Community = this;
		}
		
		private void detach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.Community = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _Username;
		
		private string _UserPassword;
		
		private string _UserEmail;
		
		private System.DateTime _Birthdate;
		
		private EntitySet<Community> _Communities;
		
		private EntitySet<CommunitiesUser> _CommunitiesUsers;
		
		private EntitySet<Post> _Posts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnUserPasswordChanging(string value);
    partial void OnUserPasswordChanged();
    partial void OnUserEmailChanging(string value);
    partial void OnUserEmailChanged();
    partial void OnBirthdateChanging(System.DateTime value);
    partial void OnBirthdateChanged();
    #endregion
		
		public User()
		{
			this._Communities = new EntitySet<Community>(new Action<Community>(this.attach_Communities), new Action<Community>(this.detach_Communities));
			this._CommunitiesUsers = new EntitySet<CommunitiesUser>(new Action<CommunitiesUser>(this.attach_CommunitiesUsers), new Action<CommunitiesUser>(this.detach_CommunitiesUsers));
			this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
			OnCreated();
		}

        public User(string username, string userPassword, string userEmail, DateTime birthdate) : this()
        {
            _Username = username;
            _UserPassword = userPassword;
            _UserEmail = userEmail;
            _Birthdate = birthdate;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPassword", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string UserPassword
		{
			get
			{
				return this._UserPassword;
			}
			set
			{
				if ((this._UserPassword != value))
				{
					this.OnUserPasswordChanging(value);
					this.SendPropertyChanging();
					this._UserPassword = value;
					this.SendPropertyChanged("UserPassword");
					this.OnUserPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserEmail", DbType="VarChar(50)")]
		public string UserEmail
		{
			get
			{
				return this._UserEmail;
			}
			set
			{
				if ((this._UserEmail != value))
				{
					this.OnUserEmailChanging(value);
					this.SendPropertyChanging();
					this._UserEmail = value;
					this.SendPropertyChanged("UserEmail");
					this.OnUserEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="Date NOT NULL")]
		public System.DateTime Birthdate
		{
			get
			{
				return this._Birthdate;
			}
			set
			{
				if ((this._Birthdate != value))
				{
					this.OnBirthdateChanging(value);
					this.SendPropertyChanging();
					this._Birthdate = value;
					this.SendPropertyChanged("Birthdate");
					this.OnBirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Community", Storage="_Communities", ThisKey="UserID", OtherKey="CommunityAdmin")]
		public EntitySet<Community> Communities
		{
			get
			{
				return this._Communities;
			}
			set
			{
				this._Communities.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_CommunitiesUser", Storage="_CommunitiesUsers", ThisKey="UserID", OtherKey="UserID")]
		public EntitySet<CommunitiesUser> CommunitiesUsers
		{
			get
			{
				return this._CommunitiesUsers;
			}
			set
			{
				this._CommunitiesUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Post", Storage="_Posts", ThisKey="UserID", OtherKey="AuthorID")]
		public EntitySet<Post> Posts
		{
			get
			{
				return this._Posts;
			}
			set
			{
				this._Posts.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Communities(Community entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Communities(Community entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_CommunitiesUsers(CommunitiesUser entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_CommunitiesUsers(CommunitiesUser entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Posts(Post entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CommunitiesUsers")]
	public partial class CommunitiesUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CommunityID;
		
		private int _UserID;
		
		private EntityRef<Community> _Community;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCommunityIDChanging(int value);
    partial void OnCommunityIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
		
		public CommunitiesUser()
		{
			this._Community = default(EntityRef<Community>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}

        public CommunitiesUser(int communityID, int userID) : this()
        {
            _CommunityID = communityID;
            _UserID = userID;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommunityID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CommunityID
		{
			get
			{
				return this._CommunityID;
			}
			set
			{
				if ((this._CommunityID != value))
				{
					if (this._Community.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCommunityIDChanging(value);
					this.SendPropertyChanging();
					this._CommunityID = value;
					this.SendPropertyChanged("CommunityID");
					this.OnCommunityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Community_CommunitiesUser", Storage="_Community", ThisKey="CommunityID", OtherKey="CommunityID", IsForeignKey=true)]
		public Community Community
		{
			get
			{
				return this._Community.Entity;
			}
			set
			{
				Community previousValue = this._Community.Entity;
				if (((previousValue != value) 
							|| (this._Community.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Community.Entity = null;
						previousValue.CommunitiesUsers.Remove(this);
					}
					this._Community.Entity = value;
					if ((value != null))
					{
						value.CommunitiesUsers.Add(this);
						this._CommunityID = value.CommunityID;
					}
					else
					{
						this._CommunityID = default(int);
					}
					this.SendPropertyChanged("Community");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_CommunitiesUser", Storage="_User", ThisKey="UserID", OtherKey="UserID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.CommunitiesUsers.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.CommunitiesUsers.Add(this);
						this._UserID = value.UserID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Posts")]
	public partial class Post : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PostID;
		
		private System.Nullable<int> _AuthorID;
		
		private System.Nullable<int> _CommunityID;
		
		private string _PostTitle;
		
		private string _PostText;
		
		private System.Nullable<System.DateTime> _PostDate;
		
		private EntityRef<User> _User;
		
		private EntityRef<Community> _Community;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPostIDChanging(int value);
    partial void OnPostIDChanged();
    partial void OnAuthorIDChanging(System.Nullable<int> value);
    partial void OnAuthorIDChanged();
    partial void OnCommunityIDChanging(System.Nullable<int> value);
    partial void OnCommunityIDChanged();
    partial void OnPostTitleChanging(string value);
    partial void OnPostTitleChanged();
    partial void OnPostTextChanging(string value);
    partial void OnPostTextChanged();
    partial void OnPostDateChanging(System.Nullable<System.DateTime> value);
    partial void OnPostDateChanged();
    #endregion
		
		public Post()
		{
			this._User = default(EntityRef<User>);
			this._Community = default(EntityRef<Community>);
			OnCreated();
		}

        public Post(int? authorID, int? communityID, string postTitle, string postText, DateTime? postDate) : this()
        {
            _AuthorID = authorID;
            _CommunityID = communityID;
            _PostTitle = postTitle;
            _PostText = postText;
            _PostDate = postDate;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorID", DbType="Int")]
		public System.Nullable<int> AuthorID
		{
			get
			{
				return this._AuthorID;
			}
			set
			{
				if ((this._AuthorID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAuthorIDChanging(value);
					this.SendPropertyChanging();
					this._AuthorID = value;
					this.SendPropertyChanged("AuthorID");
					this.OnAuthorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommunityID", DbType="Int")]
		public System.Nullable<int> CommunityID
		{
			get
			{
				return this._CommunityID;
			}
			set
			{
				if ((this._CommunityID != value))
				{
					if (this._Community.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCommunityIDChanging(value);
					this.SendPropertyChanging();
					this._CommunityID = value;
					this.SendPropertyChanged("CommunityID");
					this.OnCommunityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostTitle", DbType="VarChar(50)")]
		public string PostTitle
		{
			get
			{
				return this._PostTitle;
			}
			set
			{
				if ((this._PostTitle != value))
				{
					this.OnPostTitleChanging(value);
					this.SendPropertyChanging();
					this._PostTitle = value;
					this.SendPropertyChanged("PostTitle");
					this.OnPostTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostText", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string PostText
		{
			get
			{
				return this._PostText;
			}
			set
			{
				if ((this._PostText != value))
				{
					this.OnPostTextChanging(value);
					this.SendPropertyChanging();
					this._PostText = value;
					this.SendPropertyChanged("PostText");
					this.OnPostTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostDate", DbType="Date")]
		public System.Nullable<System.DateTime> PostDate
		{
			get
			{
				return this._PostDate;
			}
			set
			{
				if ((this._PostDate != value))
				{
					this.OnPostDateChanging(value);
					this.SendPropertyChanging();
					this._PostDate = value;
					this.SendPropertyChanged("PostDate");
					this.OnPostDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Post", Storage="_User", ThisKey="AuthorID", OtherKey="UserID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Posts.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Posts.Add(this);
						this._AuthorID = value.UserID;
					}
					else
					{
						this._AuthorID = default(Nullable<int>);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Community_Post", Storage="_Community", ThisKey="CommunityID", OtherKey="CommunityID", IsForeignKey=true)]
		public Community Community
		{
			get
			{
				return this._Community.Entity;
			}
			set
			{
				Community previousValue = this._Community.Entity;
				if (((previousValue != value) 
							|| (this._Community.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Community.Entity = null;
						previousValue.Posts.Remove(this);
					}
					this._Community.Entity = value;
					if ((value != null))
					{
						value.Posts.Add(this);
						this._CommunityID = value.CommunityID;
					}
					else
					{
						this._CommunityID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Community");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591