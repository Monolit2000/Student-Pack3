﻿using System;
using University.Interfaces;
using University.Data;
using System.Net.Http.Headers;
using University.ViewModels;

namespace University.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly UniversityContext _context;
    private readonly IDialogService _dialogService;

    private int _selectedTab;
    public int SelectedTab
    {
        get
        {
            return _selectedTab;
        }
        set
        {
            _selectedTab = value;
            OnPropertyChanged(nameof(SelectedTab));
        }
    }

    private object? _studentsSubView = null;
    public object? StudentsSubView
    {
        get
        {
            return _studentsSubView;
        }
        set
        {
            _studentsSubView = value;
            OnPropertyChanged(nameof(StudentsSubView));
        }
    }

    private object? _subjectsSubView = null;
    public object? SubjectsSubView
    {
        get
        {
            return _subjectsSubView;
        }
        set
        {
            _subjectsSubView = value;
            OnPropertyChanged(nameof(SubjectsSubView));
        }
    }

    private object? _searchSubView = null;
    public object? SearchSubView
    {
        get
        {
            return _searchSubView;
        }
        set
        {
            _searchSubView = value;
            OnPropertyChanged(nameof(SearchSubView));
        }
    }

    


    private object? _bookSubView = null;
    public object? BookSubView
    {
        get
        {
            return _bookSubView;
        }
        set
        {
            _bookSubView = value;
            OnPropertyChanged(nameof(BookSubView));
        }
    }



    private object? _athleticsFacilitySubView = null;
    public object? AthleticsFacilitySubView
    {
        get
        {
            return _athleticsFacilitySubView;
        }
        set
        {
            _athleticsFacilitySubView = value;
            OnPropertyChanged(nameof(AthleticsFacilitySubView));
        }
    }



    private object? _classroomViewModel = null;
    public object? ClassroomSubView
    {
        get
        {
            return _classroomViewModel;
        }
        set
        {
            _classroomViewModel = value;
            OnPropertyChanged(nameof(ClassroomSubView));
        }
    }



    private static MainWindowViewModel? _instance = null;
    public static MainWindowViewModel? Instance()
    {
        return _instance;
    }

    public MainWindowViewModel(UniversityContext context, IDialogService dialogService)
    {
        _context = context;
        _dialogService = dialogService;

        if (_instance is null)
        {
            _instance = this;
        }

        StudentsSubView = new StudentsViewModel(_context, _dialogService);
        SubjectsSubView = new SubjectsViewModel(_context, _dialogService);
        SearchSubView = new SearchViewModel(_context, _dialogService);
        SearchSubView = new SearchViewModel(_context, _dialogService);
        BookSubView = new BookViewModel(_context, _dialogService);
        AthleticsFacilitySubView = new AthleticsFacilitysViewModel(_context, _dialogService);
        ClassroomSubView = new ClassroomViewModel(_context, _dialogService);    
    }
}
