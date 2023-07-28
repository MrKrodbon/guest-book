<template>
    <div class="container">
        <div class="comment">
           {{commentItem}}
        </div>

    </div>
   
</template>

<script>
    export default {
        props: {
            commentItem: {
                type: Object,
                required: true
            }
        }
    }


</script>>

<style>
    .container {
        position: relative; 
        display: flex;
        width: 100%;
        height: 100%;
        margin: 0;
        padding: 0;
    }
    .comment {
        overflow-wrap: break-word;
        width: 100%;
        max-width: 900px;
        border-radius: 0.5rem;
        padding: 0.5rem;
    }
    
    
</style>