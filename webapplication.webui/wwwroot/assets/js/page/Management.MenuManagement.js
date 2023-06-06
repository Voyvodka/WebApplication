new Tagify(document.querySelector("#MenuKeyword"), { maxTags: 15 });
var menuTag = new Tagify(document.querySelector("#EditModalMenuKeyword"), { maxTags: 15 });
$(document).ready(function () {
  reloadApplicationRoles("ApplicationRoleId");
  getModuleMenuConnect();
  reloadModuleList("moduleList");
  reloadModuleList("editModule");
  reloadMenuList("menuList");
  reloadMenuList("editMenu");
  reloadMenuHeaderList("MenuHeaderId");
  reloadMenuHeaderList("editMenuHeader");
  activateDraggableModal("edit_modul");
  activateDraggableModal("edit_menuHeader");
  activateDraggableModal("edit_menu");
});
$("#module-menu-reload-button").on("click", function () {
  getModuleMenuConnect();
  reloadModuleList("moduleList");
  reloadMenuList("menuList");
});
function reloadApplicationRoles(select) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      url: "/Management/GetRoles",
      type: "GET",
    })
      .done(function (response) {
        $(`#${select}`).html("<option></option>");
        for (let role of response) {
          $(`#${select}`).append(`<option value="${role.id}">${role.name}</option>`);
        }
        resolve();
      })
      .fail(function (error) {
        reject(error);
      });
  });
}
function reloadModuleList(select) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      url: "/Management/GetModuleList",
      type: "GET",
    })
      .then(function (response) {
        $(`#${select}`).html("<option></option>");
        for (let module of response) {
          $(`#${select}`).append(`<option value="${module.moduleId}">${module.moduleText}</option>`);
        }
        resolve();
      })
      .fail(function (error) {
        reject(error);
      });
  });
}
function reloadMenuList(select) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      url: "/Management/GetMenuList",
      type: "GET",
    })
      .then(function (response) {
        $(`#${select}`).html("<option></option>");
        for (let menu of response) {
          $(`#${select}`).append(`<option value="${menu.menuId}">${menu.menuText}</option>`);
        }
        resolve();
      })
      .fail(function (error) {
        reject(error);
      });
  });
}
function reloadMenuHeaderList(select) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      url: "/Management/GetMenuHeaderList",
      type: "GET",
    })
      .then(function (response) {
        $(`#${select}`).html("<option></option>");
        for (let menuHeader of response) {
          $(`#${select}`).append(`<option value="${menuHeader.menuHeaderId}">${menuHeader.menuHeaderText}</option>`);
        }
        resolve();
      })
      .fail(function (error) {
        reject(error);
      });
  });
}
$("#add_menu_to_module").on("click", function () {
  $(this)
    .parent()
    .parent()
    .find("select")
    .each(function () {
      var elem = $(this);
      if (elem.val() == "" || elem.val() == undefined || elem.val() == null) {
        elem.removeClass("is-valid");
        elem.addClass("is-invalid");
        elem.select2();
      } else {
        elem.removeClass("is-invalid");
        elem.addClass("is-valid");
        elem.select2();
      }
    });
  var moduleId = $("#moduleList").val();
  var menuId = $("#menuList").val();
  if (moduleId != "" && menuId != "") {
    $.ajax({
      url: "/Management/AddMenuToModule",
      async: true,
      type: "POST",
      data: { moduleId: moduleId, menuId: menuId },
    }).then(function (result) {
      if (result) {
        getModuleMenuConnect();
        reloadModuleList("moduleList");
        reloadMenuList("menuList");
      } else {
        errorAlert("Seçtiğiniz menü seçtiğiniz modülde bulunuyor olabilir!");
      }
    });
  }
});
function getModuleMenuConnect() {
  $.ajax({
    url: "/Management/GetModuleMenus",
    async: true,
    type: "GET",
  }).then(function (response) {
    $("[data-module-menu-area]").empty();
    for (let module of response.modules) {
      const moduleAreaHtml = `
        <div data-area-module-id="${module.moduleId}" class="min-w-250px min-h-150px mh-300px overflow-y-auto mx-2 border border-2 border-gray-500 py-3 rounded">
            <div class="card-title m-0 d-flex justify-content-center">${module.moduleText}</div>
        </div>`;
      $("[data-module-menu-area]").append(moduleAreaHtml);
    }
    for (let moduleMenu of response.moduleMenus) {
      const areaMenuHtml = `
        <div data-module-menu="${moduleMenu.moduleMenuId}" data-area-menu-id="${moduleMenu.menuId}" class="p-2 d-flex justify-content-between bg-info rounded align-items-center m-2 " style="flex-shrink: initial;" tabindex="0">
            <h3 class="card-label fs-6 text-break m-0">${moduleMenu.menu.menuText}</h3>
            <a onclick="removeMenuFromModule($(this))" class="btn btn-icon btn-hover-light-primary cursor-pointer">
                <i class="fa-solid fa-xmark text-dark fs-1"></i>
            </a>
        </div>`;
      $(`[data-area-module-id="${moduleMenu.moduleId}"]`).append(areaMenuHtml);
    }
  });
}
function removeMenuFromModule(elem) {
  var menuId = elem.parent().attr("data-area-menu-id");
  var moduleMenuId = elem.parent().attr("data-module-menu");
  var moduleId = elem.parent().parent().attr("data-area-module-id");
  $.ajax({
    url: "/Management/RemoveModuleMenus",
    async: true,
    type: "POST",
    data: { moduleId: moduleId, menuId: menuId, moduleMenuId: moduleMenuId },
  }).then(function (result) {
    if (result) {
      elem.parent().fadeOut(300, function () {
        $(this).remove();
      });
    } else {
      errorAlert("Seçimde hata meydana geldi.");
    }
  });
}
$("#ModuleForm").on("submit", function (e) {
  console.log("aa");
  e.preventDefault();
  if (!checkInputs("ModuleForm")) return;
  var formData = new FormData(this);
  $.ajax({
    url: "/Management/SaveModule",
    type: "POST",
    async: true,
    data: formData,
    processData: false,
    contentType: false,
  }).then(function (result) {
    if (result) {
      successAlert("Modül Başarıyla Oluşturuldu");
      removeInputValue("ModuleForm");
    } else {
      errorAlert("Modül Oluşturulamadı");
    }
  });
});
$("#MenuForm").on("submit", function (e) {
  e.preventDefault();
  if (!checkInputs("MenuForm")) return;
  var formData = new FormData(this);
  $.ajax({
    url: "/Management/SaveMenu",
    type: "POST",
    async: true,
    data: formData,
    processData: false,
    contentType: false,
  }).then(function (result) {
    if (result) {
      reloadMenuList("menuList");
      reloadMenuList("editMenu");
      successAlert("Menü Başarıyla Oluşturuldu");
      removeInputValue("MenuForm");
    } else {
      errorAlert("Modül Oluşturulamadı");
    }
  });
});
$("#MenuHeaderForm").on("submit", function (e) {
  e.preventDefault();
  if (!checkInputs("MenuHeaderForm")) return;
  var formData = new FormData(this);
  $.ajax({
    url: "/Management/SaveMenuHeader",
    type: "POST",
    async: true,
    data: formData,
    processData: false,
    contentType: false,
  }).then(function (result) {
    if (result) {
      successAlert("Menu Başlığı Başarıyla Oluşturuldu");
      removeInputValue("MenuHeaderForm");
    } else {
      errorAlert("Menu Başlığı Oluşturulamadı");
    }
  });
});
$("#editModule").on("select2:select", function () {
  var elem = $(this);
  $("#edit_modul_modal").find("[data-modul-id]").attr("data-modul-id", elem.val());
  $.ajax({
    url: "/Management/GetModule",
    type: "GET",
    data: { moduleId: elem.val() },
  })
    .done(function (response) {
      if (response && response.moduleText !== undefined) {
        $("#edit_modul_modal").modal("show");
        $("#edit_modul_modal").find('[name="ModuleText"]').val(response.moduleText);
        $('[name="ModalModuleIconPath"]').val(response.moduleIconPath);
        if (response.moduleIconPath) {
          $('[name="ModalModuleIconPath"]').parent().find("button").find("i").removeAttr("class").addClass(response.moduleIconPath);
        } else {
          $('[name="ModalModuleIconPath"]').parent().find("button").find("i").removeAttr("class").addClass("fa-solid fa-icons");
        }
      }
    })
    .fail(function (e) {
      console.error(e);
    });
});
$("#edit_modul_modal").on("hide.bs.modal", function () {
  $("#editModule").val(null).trigger("change");
});
$("#edit_modul").on("submit", function (e) {
  e.preventDefault();
  var moduleId = $("#edit_modul_modal [data-modul-id]").attr("data-modul-id");
  var moduleText = $('#edit_modul [name="ModuleText"]').val();
  var moduleIcon = $('#edit_modul [name="ModalModuleIconPath"]').val();
  var requestData = {
    moduleId: moduleId,
    moduleText: moduleText,
    moduleIcon: moduleIcon,
  };
  $.ajax({
    url: "/Management/UpdateModule",
    type: "POST",
    data: requestData,
  }).done(function (response) {
    if (response) {
      $("#edit_modul_modal").modal("hide");
      reloadModuleList("editModule");
    }
  });
});
$("#editMenuHeader").on("select2:select", function () {
  var elem = $(this);
  $("#edit_menuheader_modal").find("[data-menu-header-id]").attr("data-menu-header-id", elem.val());
  $.ajax({
    url: "/Management/GetMenuHeader",
    type: "GET",
    data: { menuHeaderId: elem.val() },
  })
    .done(function (response) {
      if (response && response.menuHeaderText !== undefined) {
        $("#edit_menuheader_modal").modal("show");
        $("#edit_menuheader_modal").find('[name="MenuHeaderText"]').val(response.menuHeaderText);
        $('[name="ModalMenuHeaderIconPath"]').val(response.menuHeaderIconPath);
        if (response.menuHeaderIconPath) {
          $('[name="ModalMenuHeaderIconPath"]').parent().find("button").find("i").removeAttr("class").addClass(response.menuHeaderIconPath);
        } else {
          $('[name="ModalMenuHeaderIconPath"]').parent().find("button").find("i").removeAttr("class").addClass("fa-solid fa-icons");
        }
      }
    })
    .fail(function (e) {
      console.error(e);
    });
});
$("#edit_menuheader_modal").on("hide.bs.modal", function () {
  $("#editMenuHeader").val(null).trigger("change");
});
$("#edit_menuHeader").on("submit", function (e) {
  e.preventDefault();
  var menuHeaderId = $("#edit_menuheader_modal [data-menu-header-id]").attr("data-menu-header-id");
  var menuHeaderText = $('#edit_menuHeader [name="MenuHeaderText"]').val();
  var menuHeaderIcon = $('#edit_menuHeader [name="ModalMenuHeaderIconPath"]').val();
  var requestData = {
    menuHeaderId: menuHeaderId,
    menuHeaderText: menuHeaderText,
    menuHeaderIcon: menuHeaderIcon,
  };
  $.ajax({
    url: "/Management/UpdateMenuHeader",
    type: "POST",
    data: requestData,
  }).done(function (response) {
    if (response) {
      $("#edit_menuheader_modal").modal("hide");
      reloadMenuHeaderList("editMenuHeader");
    }
  });
});
$("#editMenu").on("select2:select", function () {
  var elem = $(this);
  $("#edit_menu_modal").find("[data-menu-id]").attr("data-menu-id", elem.val());
  $.ajax({
    url: "/Management/GetMenu",
    type: "GET",
    data: { menuId: elem.val() },
  })
    .done(function (response) {
      if (response && response.menuText !== undefined) {
        reloadMenuHeaderList("editMenu_menuHeaders").then(function () {
          $('#edit_menu_modal [name="MenuHeaderId"]').val(response.menuHeaderId).trigger("change");
        });
        reloadApplicationRoles("EditModalRoles").then(function () {
          $('#edit_menu_modal [name="ApplicationRoleId"]').val(response.applicationRoleId).trigger("change");
        });
        $("#edit_menu_modal").modal("show");
        $('#edit_menu_modal [name="MenuId"]').val(response.menuId);
        $('#edit_menu_modal [name="MenuText"]').val(response.menuText);
        $('#edit_menu_modal [name="MenuHref"]').val(response.menuHref);
        $('[name="ModalMenuIconPath"]').val(response.menuIconPath);
        menuTag.removeAllTags();
        menuTag.addTags(response.menuKeyword.split("~"));
        $("#EditModalMenuKeyword");
        if (response.menuIconPath) {
          $('[name="ModalMenuIconPath"]').parent().find("button").find("i").removeAttr("class").addClass(response.menuIconPath);
        } else {
          $('[name="ModalMenuIconPath"]').parent().find("button").find("i").removeAttr("class").addClass("fa-solid fa-icons");
        }
      }
    })
    .fail(function (error) {
      reject(error);
    });
});
$("#edit_menu_modal").on("hide.bs.modal", function () {
  $("#editMenu").val(null).trigger("change");
});
$("#edit_menu").on("submit", function (e) {
  e.preventDefault();
  var formData = new FormData($(this)[0]);
  formData.append("MenuIconPath", $('[name="ModalMenuIconPath"]').val());
  $.ajax({
    url: "/Management/UpdateMenu",
    type: "POST",
    data: formData,
    processData: false,
    contentType: false,
  }).done(function (response) {
    if (response) {
      $("#edit_menu_modal").modal("hide");
      reloadMenuList("editMenu");
    }
  });
});
