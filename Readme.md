Syarat yang diperlukan:
- sudah terbiasa menggunakan aplikasi berbasis web
- pengetahuan dasar cara menjalankan aplikasi web dari source code
- dotnet runtime versi >= 8 sudah terinstall di operasi sistem
- moderen web browser merek apa saja

Tahapan:
- jalankan program dari source code
- buka web browser dan arahkan URL ke http://localhost:3219
- masukan nama dan nomor telfon, lalu klik tombol Add, ulangi untuk menambahkan
- kontak yang sudah di masukan akan tampil beserta fungsi tombol lainnya
- tombol Delete disamping kontak berfungsi menghapus satu kontak
- tombol Delete All berfungsi menghapus semua kontak
- tombol Generate .vcf berfungsi membuat vCard.vcf sekaligus mendownloadnya
- gunakan file tersebut sesuai kebutuhan

Pernyataan Bantahan:
- dipersilahkan menggunakan, memodifikasi, dan menyebarluaskan aplikasi vCardMaker
- projek ini hanyalah sekedar latihan koding bagi kreator
- sengaja tidak dibuat file presentasi disebabkan projek kedua ini hampir sama dengan projek pertama
- sengaja tidak memakai javascript dan turunannya untuk fokus pada penggunaan teknologi seminimal mungkin
- happy koding!!!

-----------------------------------------------------------------------------------
Add new features generate excel at commit: 6ec37a727f82686a346779cb3ff4345f04f1b947

Fitur baru ditambah:
- terdapat tombol Generate Excel untuk mendownload file vCardMakerExcel
- berfungsi untuk menampilkan data dalam bentuk spreadsheet dengan ekstensi .xlsx
- hanya untuk penyajian data, tidak diperuntukan import kontak ke ponsel
