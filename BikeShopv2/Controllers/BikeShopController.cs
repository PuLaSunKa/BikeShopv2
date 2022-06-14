using BikeShopv2.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeShopv2.Controllers
{
    public class BikeShopController : Controller
    {
        // GET: BikeShop
        BikeShopDataContext data = new BikeShopDataContext();
        // Hàm lấy n sản phẩm mới
        private List<SANPHAM> LaySanPham(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.SANPHAMs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        //Phương thức Index: Không có tham số (null) hoặc có tham số là số nguyên (biến page)
        public ActionResult Index(int? page)
        {
            //kích thước trang = số mẫu tin cho 1 trang
            int pagesize = 5;
            //Số thứ tự trang: nêu page là null thì pagenum = 1, ngược lại pagenum = page
            int pagenum = (page ?? 1);
            //Lấy top 5 bán chạy nhất;
            var sp = LaySanPham(15);
            return View(sp.ToPagedList(pagenum, pagesize));
        }
        public ActionResult LoaiSanPham()
        {
            var lsp = from s in data.LOAISANPHAMs select s;
            return PartialView(lsp);
        }

        public ActionResult SanPhamTheoLoai(int id)
        {
            var sptl = from s in data.SANPHAMs where s.ID_LSP == id select s;
            return View(sptl);

        }
        public ActionResult Brand()
        {
            var br = from s in data.BRANDs select s;
            return PartialView(br);
        }
        public ActionResult SanPhamTheoBrand(int id)
        {
            var spbr = from s in data.SANPHAMs where s.ID_BRAND == id select s;
            return View(spbr);

        }
        public ActionResult ChiTietSanPham(int id)
        {
            var sp = from s in data.SANPHAMs where s.ID_SANPHAM == id select s;
            return View(sp.Single());
        }
    }
}