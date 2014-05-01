using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Alta_Media_Manager.Alta_view.Class;

namespace Alta_Media_Manager.Plugin
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate CameraTemplate { get; set; }
        public DataTemplate VideoTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            alta_class_media media = item as alta_class_media;
            if (media != null)
            {
                if (media.alta_media_type.alta_id == 1)
                    return VideoTemplate;
                else
                    return CameraTemplate;
            }
            else
            {
                return VideoTemplate;
            }
        }
    }
}