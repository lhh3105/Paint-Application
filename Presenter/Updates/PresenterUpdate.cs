﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_offi.Presenter.Updates
{
    interface PresenterUpdate
    {

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn chế độ select
        /// </summary>
        void onClickSelectMode();

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn thay đổi màu sắc
        /// </summary>
        /// <param name="color">Màu cần đổi</param>
        /// <param name="g">Áp dụng lên graphic g</param>
        void onClickSelectColor(Color color, Graphics g);

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn thay đôi kích thước đường vẽ
        /// </summary>
        /// <param name="size"></param>
        void onClickSelectSize(int size);

        /// <summary>
        /// Phương thức xử lý khi người dụng chọn chế độ fill
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="g"></param>
        void onClickSelectFill(Button btn, Graphics g);


    }
}
