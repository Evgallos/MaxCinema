### 🔥 **MaxCinema Project Overview (Nov 2024)** 🔥  

**Project Name:** MaxCinema  
**Duration:** November 15 - November 25, 2024  
**Assigned by:** Lexicon School  
**Team Members:** 3 students  
**Role:** **Front-End Developer (80%)** & Partial **Back-End Developer**  
**Technologies Used:**  
- **Back-End:** C#, Ajax, LINQ  
- **Front-End:** HTML, CSS, Bootstrap, JavaScript (jQuery)  
- **Tools:** **Visual Studio 2022, MVC, SQL, Figma (Wireframes)**  

---

### **📌 Project Details:**  
MaxCinema is a fully responsive website designed for purchasing digital movie copies. The project includes essential features like:  
✅ **User authentication & storage**  
✅ **Admin panel for managing content**  
✅ **Movie library with details & purchase system**  
✅ **Shopping cart functionality**  
✅ **Custom-designed UI elements (dropdowns, buttons, colors, backgrounds, etc.)**  
✅ **Accordion components & interactive UI elements**  

---

### **🛠 My Contributions:**  
🎨 **Front-End Development (80%)**  
- Designed and implemented the entire UI, including colors, backgrounds, dropdowns, buttons, and interactive elements.  
- Ensured a fully responsive experience using **Bootstrap & CSS**.  
- Created **custom animations & transitions** for smoother navigation.  
- Designed and integrated an **accordion** component for displaying movie details efficiently.  

💾 **Back-End Development**  
- Developed multiple **C# classes & methods** to handle business logic.  
- Worked with **LINQ queries** to fetch and manipulate data efficiently.  
- Integrated **SQL database** for storing movie details & user purchases.  

🎨 **Wireframes & Prototyping**  
- Created complete **wireframes** for MaxCinema using **Figma**.  
- Defined user flows & designed UI/UX for an intuitive experience.  

---

### **🚀 Presentation & Repository**  
📌 **MaxCinema PowerPoint Presentation:**  
🔗 [View Presentation](https://1drv.ms/p/c/66f1ad52fc8c2bf9/Ee9_d7p_CutFja_6ojT_w1gBCoSAl0-rsDzaqI5AQvcoWA?e=ul4zJO)  

📌 **GitHub Repository:**  
🔗 [MaxCinema GitHub Repo](https://www.github.com/Evgallos/MaxCinema)  

📌 **Portfolio Website:**  
🔗 [www.evgallos.com](https://www.evgallos.com)  

---

### **📜 Copyright License**  
All source code and assets of **MaxCinema** are copyrighted.  
🔹 **Only I (Evangelos Gallos) and my two teammates** have rights to the code.  
🔹 Unauthorized use, distribution, or modification is prohibited.  

---

The following **YAML** code includes a **JavaScript** script that I implemented and customized for the **MaxCinema** project. This script adds a "Scroll to Top" button to the website, using **jQuery** to detect when the user scrolls down. Once the user scrolls past a certain point, the button appears, allowing smooth scrolling back to the top when clicked. The original idea was sourced from open resources, but I modified and integrated it specifically for this project.

### **📝 YAML Configuration (Code Snippet)**  
```yaml
code_snippets:
  - language: CSS
    description: "Styling for MaxCinema project"
    code: |
      body {
          font-family: 'Arial', sans-serif;
          background-color: #f8f9fa;
      }
      .navbar {
          background-color: #343a40 !important;
      }
      .navbar-brand {
          color: #ffffff !important;
      }
      .cart-container {
          position: relative;
      }
      .cart-icon {
          color: #ffffff;
      }
      #scrollToTopBtn {
          display: none;
          position: fixed;
          bottom: 20px;
          right: 20px;
          background-color: #343a40;
          color: white;
          border: none;
          border-radius: 5px;
          padding: 10px;
          cursor: pointer;
      }
  - language: JavaScript
    description: "Scroll-to-top functionality for MaxCinema"
    code: |
      $(window).scroll(function () {
          if ($(this).scrollTop() > 100) {
              $('#scrollToTopBtn').fadeIn();
          } else {
              $('#scrollToTopBtn').fadeOut();
          }
      });

      function scrollToTop() {
          $('html, body').animate({ scrollTop: 0 }, 500);
      }
```  
---

### ✅ **Final Notes:**  
MaxCinema was a successful project that showcased my skills in **front-end & back-end development, UI/UX design, and responsive web design**. Working on this project significantly enhanced my expertise in **C#, MVC, LINQ, JavaScript, and Bootstrap**.
