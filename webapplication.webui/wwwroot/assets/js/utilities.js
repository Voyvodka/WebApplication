function checkInputs(formId) {
  const getform = "#" + formId;
  var result = true;
  $(getform)
    .find("input:required")
    .each(function () {
      if ($(this).val() === "") {
        result = false;
      }
    });
  $(getform)
    .find("select:required")
    .each(function () {
      if ($(this).val() === "") {
        result = false;
      }
    });
  $(getform)
    .find("textarea:required")
    .each(function () {
      if ($(this).val() === "") {
        result = false;
      }
    });
  if (result === false) {
    Swal.fire({
      text: "Zorunlu belirtilen tüm alanları doldurunuz",
      icon: "error",
      timer: 1200,
      showConfirmButton: false,
      showDenyButton: true,
      denyButtonText: "Tamam",
      buttonsStyling: false,
      customClass: {
        denyButton: "btn btn-danger btn-sm",
      },
    });
    return result;
  }
  return true;
}
function removeInputValue(formId) {
  $("#" + formId + " input").val("");
  $("#" + formId + " textarea").val("");
  $("#" + formId + " select")
    .val("")
    .trigger("change");
  $("#" + formId)
    .find('[data-kt-image-input-action="cancel"]')
    .click();
}
function successAlert(text) {
  Swal.fire({
    text: text,
    icon: "success",
    timer: 2000,
    confirmButtonText: "Tamam",
    buttonsStyling: false,
    customClass: {
      confirmButton: "btn btn-success btn-sm",
    },
  });
}
function errorAlert(text) {
  Swal.fire({
    text: text,
    icon: "error",
    timer: 2000,
    confirmButtonText: "Tamam",
    buttonsStyling: false,
    customClass: {
      confirmButton: "btn btn-danger btn-sm",
    },
  });
}
function activateDraggable() {
  var containers = document.querySelectorAll(".min-h-200px.draggable-zone");
  if (containers.length === 0) {
    return false;
  }
  var swappable = new Sortable.default(containers, {
    draggable: ".draggable",
    handle: ".draggable .draggable-handle",
    mirror: {
      //appendTo: selector,
      appendTo: "body",
      constrainDimensions: true,
    },
  });
}
