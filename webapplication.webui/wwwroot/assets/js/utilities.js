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
function formatDate(isoDate) {
  if (isoDate == null) return "";
  const date = new Date(isoDate);
  const day = date.getDate();
  const month = date.getMonth() + 1;
  const year = date.getFullYear();
  const hours = date.getHours();
  const minutes = date.getMinutes();
  const seconds = date.getSeconds();
  return `${hours}:${minutes}:${seconds} ${day}.${month}.${year}`;
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
  var droppable = new Sortable.default(containers, {
    draggable: ".draggable",
    handle: ".draggable .draggable-handle",
    dropzone: ".draggable-zone",
    mirror: {
      //appendTo: selector,
      appendTo: "body",
      constrainDimensions: true,
    },
  });
  const restrcitedWrapper = document.querySelector('[data-kt-draggable-level="restricted"]');
  let droppableOrigin;
  droppable.on("drag:start", (e) => {
    droppableOrigin = e.originalSource.getAttribute("data-draggable-card");
  });
  droppable.on("drag:over", (e) => {
    const isRestricted = Array.from(e.overContainer.querySelectorAll(`[data-draggable-card="${droppableOrigin}"]`));
    isRestricted.shift();
    let isSameItemInContainer = false;
    for (let item of isRestricted) {
      if (item.getAttribute("data-draggable-card") == e.originalSource.getAttribute("data-draggable-card")) {
        isSameItemInContainer = true;
      } else {
        isSameItemInContainer = false;
      }
    }
    if (isSameItemInContainer) {
      e.cancel();
    }
  });
  droppable.on("drag:stop", (e) => {
    // remove all draggable occupied limit
    containers.forEach((c) => {
      c.classList.remove("draggable-dropzone--occupied");
    });
  });
  droppable.on("droppable:dropped", (e) => {
    const isRestricted = Array.from(e.overContainer.querySelectorAll(`[data-draggable-card="${droppableOrigin}"]`));
    isRestricted.shift();
    let isSameItemInContainer = false;
    for (let item of isRestricted) {
      if (item.getAttribute("data-draggable-card") == e.originalSource.getAttribute("data-draggable-card")) {
        isSameItemInContainer = true;
      } else {
        isSameItemInContainer = false;
      }
    }
    if (isSameItemInContainer) {
      e.cancel();
    }
  });
}
function activateDraggableModal(elem) {
  var element = document.querySelector("#" + elem);
  dragElement(element);
  function dragElement(elmnt) {
    var pos1 = 0,
      pos2 = 0,
      pos3 = 0,
      pos4 = 0;
    if (elmnt.querySelector(".modal-header")) {
      elmnt.querySelector(".modal-header").onmousedown = dragMouseDown;
    } else {
      elmnt.onmousedown = dragMouseDown;
    }
    function dragMouseDown(e) {
      e = e || window.event;
      e.preventDefault();
      pos3 = e.clientX;
      pos4 = e.clientY;
      document.onmouseup = closeDragElement;
      document.onmousemove = elementDrag;
    }
    function elementDrag(e) {
      e = e || window.event;
      e.preventDefault();
      pos1 = pos3 - e.clientX;
      pos2 = pos4 - e.clientY;
      pos3 = e.clientX;
      pos4 = e.clientY;
      elmnt.style.top = elmnt.offsetTop - pos2 + "px";
      elmnt.style.left = elmnt.offsetLeft - pos1 + "px";
    }
    function closeDragElement() {
      document.onmouseup = null;
      document.onmousemove = null;
    }
  }
}
