<template>
    <div class="container">
        <img src="../assets/background.jpg" class="backgorund-image" />
        <div class="comment">
            <button v-if="!isFormActive" @click="isFormActive = true" class="button-success">
                Add new comment
            </button>
            <template ></template>
            <h3 v-else>New comment</h3>
        </div>

    </div>
   
</template>

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
    .backgorund-image {
        flex: 1;
        max-width: 900px;
        height: 100%;
        
    }
</style>