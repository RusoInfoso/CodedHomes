﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodedHomes.Web.Models;

namespace CodedHomes.Web.ViewModels
{
    public class ViewModelBase
    {
        private bool? _canEdit = null;
        private bool? _canDelete = null;

        private readonly RoleEvaluator _evaluator = new RoleEvaluator();

        public bool CanEdit
        {
            get
            {
                if (!this._canEdit.HasValue)
                {
                    this._canEdit = this._evaluator.CanEdit;
                }
                return this._canEdit.Value;
            }
        }

        public bool CanDelete
        {
            get
            {
                if (!this._canDelete.HasValue)
                {
                    this._canDelete = this._evaluator.CanDelete;
                }
                return this._canDelete.Value;
            }
        }
    }
}