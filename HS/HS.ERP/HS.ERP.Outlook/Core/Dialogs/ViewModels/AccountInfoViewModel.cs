﻿using System;
using System.Collections.ObjectModel;
using HS.ERP.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace HS.ERP.Outlook.Core.Dialogs.ViewModels
{
   public class AccountInfoViewModel : BindableBase, IDialogAware
   {
      private ObservableCollection<object> _accountList;

      private IDataManager<object> DataManager { get; }

      public ObservableCollection<object> AccountList
      {
         get { return _accountList; }
         set { SetProperty(ref _accountList, value); }
      }

      public AccountInfoViewModel(IDataManager<object> dataManager)
      {

         this.DataManager = dataManager;
         CloseDialogCommand = new DelegateCommand<string>(CloseDialog);

         //   private int? _id;
         //private string _companyName;
         //private string _companyManager;
         //private string _phoneNumber;
         //private string _email;
         //private string _address;
         //private string _description;
         //private DateTime _createdDate;
         //private DateTime _updatedDate;
      }

      public DelegateCommand<string> CloseDialogCommand { get; private set; }

      public event Action<IDialogResult> RequestClose;

      private void CloseDialog(string parameter)
      {
         ButtonResult result = ButtonResult.None;
         var transportParameter = new DialogParameters();
         string parameterValue = string.Empty;

         if (parameter?.ToLower() == "true")
         {
            result = ButtonResult.OK;
            parameterValue = "ButtonResult.OK";
         }

         transportParameter.Add("submessage", parameterValue);
         RaiseRequestClose(result, transportParameter);
      }

      private void RaiseRequestClose(ButtonResult dialogResult, DialogParameters dialogParameters)
        => RequestClose?.Invoke(new DialogResult(dialogResult, dialogParameters));

      public bool CanCloseDialog()
      {
         return true;
      }

      public void OnDialogClosed()
      {

      }

      public void OnDialogOpened(IDialogParameters parameters)
      {
         //Message = parameters.GetValue<string>("message");
      }

      #region TitleName

      private string _message;
      public string Message
      {
         get => _message;
         set { SetProperty(ref _message, value); }
      }

      public string Title => "Account";

      #endregion
   }
}
