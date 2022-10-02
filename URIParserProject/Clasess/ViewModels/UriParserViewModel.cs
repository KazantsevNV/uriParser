using Clasess.Comands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Clasess.ViewModels
{
    public class UriParserViewModel : AbstractViewModel
    {
        private readonly UriValidator _validator;
        private readonly Loader _loader;
        private readonly IParser _parser;

        private string _uriString;
        public string UriString
        {
            get => _uriString;
            set
            {
                _uriString = value?.Trim();
                OnPropertyChanged("UriString");
            }
        }

        private int _hrefCount;
        public int HrefCount
        {
            get => _hrefCount;
            set
            {
                _hrefCount = value;
                OnPropertyChanged("HrefCount");
            }
        }

        private ObservableCollection<Record> _records = new ObservableCollection<Record>();
        public ObservableCollection<Record> Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged("Records");
            }
        }

        public UriParserViewModel(IParser parser) 
        {
            _validator = new UriValidator();
            _loader = new Loader();
            _parser = parser;
        }

        private RelayCommand parseCommand;
        public RelayCommand ParseCommand
        {
            get
            {
                return parseCommand ??= new RelayCommand(obj =>
                {
                    if (_validator.IsValidUri(UriString))
                    {
                        var uri = new Uri(UriString);
                        var document = _loader.Load(uri);
                        if (document == null)
                        {
                            EditRecords(new List<Record>(), 0);
                            return;
                        }
                        EditRecords(_parser.Parse(document, uri, out var count), count);
                    }
                    else 
                    {
                        EditRecords(new List<Record>(), 0);
                        MessageBox.Show($"Некорректный URL - {UriString}", "Ошибка");
                    }
                });
            }
        }

        private void EditRecords(List<Record> list, int count) 
        {
            Records = new ObservableCollection<Record>(list);
            HrefCount = count;
        }
    }
}
