var LastId=0;
function applyDragAndDrop(mainContainer, containerOne, containerTwo, dragItem) {
    $(dragItem).draggable(
        {       
			revert:"invalid",
            containment: mainContainer,
            helper: "clone",
            cursor: "move",
			drag: function (event, ui) {
                $(ui.helper).addClass("active_element");
            },
            stop: function (event, ui) {
                $(ui.helper).removeClass("active_element");				
            }
        });

    $(containerTwo).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            
			//add element
				var el = ui.draggable.clone();				
				el.attr("id", "form" + LastId);
				LastId++;
				
				el.css({ "left": ui.position.left-$(containerTwo).offset().left, "top": ui.position.top-$(containerTwo).offset().top, "position": "absolute" });
				$(containerTwo).append(el);
				acceptElementToTwo(ui.draggable);
        }
    });

    $(containerOne).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {           
            acceptElementToOne(ui.draggable);
			$(ui.helper.prevObject).remove();
			$(ui.helper).remove();
        }
    });

    function acceptElementToTwo(item) {
        
        // $(containerOne).append(item.clone());
        $(item).removeClass("active_element");
		$('#form_contains').val($('#form_contains').val() + $(item).attr("id")+"|" + $(item).html() + "|" + $(item).position().left + "|" + $(item).position().top + "|" + $(item).width() + "|" + $(item).height() + ";");
        
		//add reaction to remove:
		$("#form_view .form_element").draggable(
        {       
			revert:"invalid",
            containment: mainContainer,
            cursor: "move",
			drag: function (event, ui) {
                $(ui.helper).addClass("active_element");
            },
            stop: function (event, ui) {
                $(ui.helper).removeClass("active_element");				
            }
        });
         
    }

    function acceptElementToOne(item) {
        $(item).removeClass("active_element");        
    }
}
$(document).ready(function () {
			LastId=0;
            applyDragAndDrop("#form_drag_drop", "#toolbox", "#form_view", ".form_element");
        });